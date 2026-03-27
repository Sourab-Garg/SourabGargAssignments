"""
train.py – Main training entry point for the Diabetes Thesis v2 prediction system.

Usage
-----
Thesis track (LR + RF + tuned XGBoost + hybrid weighted ensemble):
    python train.py --track thesis

Requested track (tuned XGBoost + tuned KNN + DNN):
    python train.py --track requested

Optional overrides:
    python train.py --track thesis --config path/to/config.yaml --data path/to/diabetes.csv
"""

import argparse
import os
import sys
import warnings
import numpy as np

warnings.filterwarnings("ignore")

# Ensure the project root is on the path when running from subdirectory
sys.path.insert(0, os.path.dirname(__file__))

from src.data import load_data, split_features_target
from src.preprocessing import replace_invalid_zeros, stratified_split, build_preprocessor
from src.feature_selection import select_features_rfe
from src.models import (
    train_logistic_regression,
    train_random_forest,
    train_xgboost_tuned,
    train_knn_tuned,
    train_dnn,
)
from src.ensemble import HybridWeightedEnsemble, get_probas_from_sklearn
from src.evaluate import (
    evaluate_model,
    print_results_table,
    save_metrics_csv,
    save_performance_plot,
)
from src.utils import (
    save_artifact,
    save_keras_model,
    load_config,
)


# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

def _parse_args():
    parser = argparse.ArgumentParser(description="Diabetes Thesis v2 – Training")
    parser.add_argument(
        "--track",
        choices=["thesis", "requested"],
        default="thesis",
        help="'thesis' = LR+RF+XGB+ensemble  |  'requested' = XGB+KNN+DNN",
    )
    parser.add_argument(
        "--config",
        default="config.yaml",
        help="Path to config.yaml (default: config.yaml)",
    )
    parser.add_argument(
        "--data",
        default=None,
        help="Override data path from config.yaml",
    )
    return parser.parse_args()


def _get_cfg_value(cfg: dict, *keys, default=None):
    """Safe nested dict lookup."""
    val = cfg
    for k in keys:
        if not isinstance(val, dict):
            return default
        val = val.get(k, default)
        if val is default:
            return default
    return val


# ---------------------------------------------------------------------------
# Thesis track
# ---------------------------------------------------------------------------

def run_thesis_track(cfg: dict, X_train, X_test, y_train_bal, y_test, artifacts_dir: str):
    """LR + RF + tuned XGBoost + hybrid weighted ensemble.

    Ensemble weights are derived from a held-out validation set carved out of the
    training data (no test-set data leakage).  After weights are fixed, each model
    is re-trained on the full training set before evaluation on the test set.
    """
    from sklearn.model_selection import train_test_split as _tts

    print("\n" + "=" * 55)
    print("  THESIS TRACK: LR + RF + XGBoost + Hybrid Ensemble")
    print("=" * 55)

    xgb_params = _get_cfg_value(cfg, "models", "xgboost", "param_grid")
    xgb_cv = _get_cfg_value(cfg, "models", "xgboost", "cv", default=5)
    rf_n = _get_cfg_value(cfg, "models", "random_forest", "n_estimators", default=200)
    rf_depth = _get_cfg_value(cfg, "models", "random_forest", "max_depth", default=10)
    rs = _get_cfg_value(cfg, "data", "random_state", default=42)

    # --- Step 1: hold out 20 % of training data to derive ensemble weights ---
    X_tr, X_val, y_tr, y_val = _tts(
        X_train, y_train_bal, test_size=0.2, random_state=rs, stratify=y_train_bal
    )

    lr_model = train_logistic_regression(X_tr, y_tr, random_state=rs)
    rf_model = train_random_forest(X_tr, y_tr, n_estimators=rf_n, max_depth=rf_depth, random_state=rs)
    xgb_model, _ = train_xgboost_tuned(
        X_tr, y_tr, param_grid=xgb_params, cv=xgb_cv, random_state=rs
    )

    component_models_val = {"LR": lr_model, "RF": rf_model, "XGBoost": xgb_model}
    val_f1 = {
        name: evaluate_model(y_val, mdl.predict(X_val))["F1"]
        for name, mdl in component_models_val.items()
    }
    ensemble = HybridWeightedEnsemble(model_names=list(component_models_val.keys()))
    ensemble.fit_weights(val_f1)

    # --- Step 2: re-train on the full training set with weights now fixed ---
    lr_model = train_logistic_regression(X_train, y_train_bal, random_state=rs)
    rf_model = train_random_forest(X_train, y_train_bal, n_estimators=rf_n, max_depth=rf_depth, random_state=rs)
    xgb_model, xgb_best = train_xgboost_tuned(
        X_train, y_train_bal, param_grid=xgb_params, cv=xgb_cv, random_state=rs
    )
    component_models = {"LR": lr_model, "RF": rf_model, "XGBoost": xgb_model}

    # --- Step 3: evaluate on test set ---
    results = {}
    for name, mdl in component_models.items():
        results[name] = evaluate_model(y_test, mdl.predict(X_test))

    probas = get_probas_from_sklearn(component_models, X_test)
    ensemble_preds = ensemble.predict(probas)
    results["Ensemble"] = evaluate_model(y_test, ensemble_preds)

    # --- Step 4: persist artifacts ---
    for name, mdl in component_models.items():
        save_artifact(mdl, os.path.join(artifacts_dir, f"model_{name.lower()}.pkl"))
    save_artifact(ensemble, os.path.join(artifacts_dir, "ensemble.pkl"))

    return results


# ---------------------------------------------------------------------------
# Requested track
# ---------------------------------------------------------------------------

def run_requested_track(cfg: dict, X_train, X_test, y_train_bal, y_test, artifacts_dir: str):
    """Tuned XGBoost + tuned KNN + DNN."""
    print("\n" + "=" * 55)
    print("  REQUESTED TRACK: XGBoost + KNN + DNN")
    print("=" * 55)

    xgb_params = _get_cfg_value(cfg, "models", "xgboost", "param_grid")
    xgb_cv = _get_cfg_value(cfg, "models", "xgboost", "cv", default=5)
    knn_params = _get_cfg_value(cfg, "models", "knn", "param_grid")
    knn_cv = _get_cfg_value(cfg, "models", "knn", "cv", default=5)
    rs = _get_cfg_value(cfg, "data", "random_state", default=42)
    dnn_cfg = _get_cfg_value(cfg, "models", "dnn", default={})

    xgb_model, xgb_best = train_xgboost_tuned(
        X_train, y_train_bal,
        param_grid=xgb_params,
        cv=xgb_cv,
        random_state=rs,
    )
    knn_model, knn_best = train_knn_tuned(
        X_train, y_train_bal,
        param_grid=knn_params,
        cv=knn_cv,
    )
    dnn_model, _ = train_dnn(
        X_train, y_train_bal,
        hidden_layers=dnn_cfg.get("hidden_layers", [64, 32, 16]),
        dropout_rate=dnn_cfg.get("dropout_rate", 0.2),
        epochs=dnn_cfg.get("epochs", 150),
        batch_size=dnn_cfg.get("batch_size", 32),
        validation_split=dnn_cfg.get("validation_split", 0.2),
        patience=dnn_cfg.get("patience", 15),
        random_state=rs,
    )

    # Evaluate
    results = {}
    results["XGBoost"] = evaluate_model(y_test, xgb_model.predict(X_test))
    results["KNN"] = evaluate_model(y_test, knn_model.predict(X_test))

    dnn_prob = dnn_model.predict(X_test, verbose=0).ravel()
    dnn_pred = (dnn_prob >= 0.5).astype(int)
    results["DNN"] = evaluate_model(y_test, dnn_pred)

    # Save artifacts
    save_artifact(xgb_model, os.path.join(artifacts_dir, "model_xgboost.pkl"))
    save_artifact(knn_model, os.path.join(artifacts_dir, "model_knn.pkl"))
    dnn_path = os.path.join(artifacts_dir, "model_dnn")
    save_keras_model(dnn_model, dnn_path)

    return results


# ---------------------------------------------------------------------------
# Main
# ---------------------------------------------------------------------------

def main():
    args = _parse_args()

    # Load config
    cfg = load_config(args.config)

    # Resolve data path
    data_path = args.data or _get_cfg_value(cfg, "data", "path", default="diabetes.csv")
    target_col = _get_cfg_value(cfg, "data", "target_col", default="Outcome")
    test_size = _get_cfg_value(cfg, "data", "test_size", default=0.20)
    random_state = _get_cfg_value(cfg, "data", "random_state", default=42)
    zero_cols = _get_cfg_value(cfg, "data", "zero_invalid_cols", default=None)

    # Preprocessing config
    imputation_strategy = _get_cfg_value(cfg, "preprocessing", "imputation_strategy", default="median")
    use_smote = _get_cfg_value(cfg, "preprocessing", "use_smote", default=True)
    smote_rs = _get_cfg_value(cfg, "preprocessing", "smote_random_state", default=42)

    # Feature selection config
    fs_enabled = _get_cfg_value(cfg, "feature_selection", "enabled", default=True)
    fs_n = _get_cfg_value(cfg, "feature_selection", "n_features", default=6)

    # Artifacts dir
    artifacts_dir = _get_cfg_value(cfg, "artifacts", "dir", default="artifacts")
    os.makedirs(artifacts_dir, exist_ok=True)

    # Eval config
    metrics_csv = _get_cfg_value(cfg, "evaluation", "metrics_csv", default=os.path.join(artifacts_dir, "metrics.csv"))
    plot_png = _get_cfg_value(cfg, "evaluation", "plot_png", default=os.path.join(artifacts_dir, "performance_plot.png"))

    print(f"\n[train] Track: {args.track.upper()}")

    # 1. Load data
    df = load_data(data_path)

    # 2. Replace invalid zeros
    df = replace_invalid_zeros(df, cols=zero_cols)

    # 3. Split features / target
    X, y = split_features_target(df, target_col)

    # 4. Stratified train/test split
    X_train_df, X_test_df, y_train, y_test = stratified_split(X, y, test_size, random_state)

    # 5. Imputation, scaling, SMOTE
    prep = build_preprocessor(
        X_train_df, X_test_df, y_train,
        imputation_strategy=imputation_strategy,
        use_smote=use_smote,
        smote_random_state=smote_rs,
    )
    X_train = prep["X_train_bal"]
    X_test = prep["X_test_scaled"]
    y_train_bal = prep["y_train_bal"]
    y_test_arr = np.asarray(y_test)

    # 6. Optional RFE feature selection
    feature_mask = None
    rfe_selector = None
    if fs_enabled:
        X_train, X_test, feature_mask, rfe_selector = select_features_rfe(
            X_train, y_train_bal, X_test,
            n_features=fs_n,
            random_state=random_state,
        )

    # Save preprocessors
    save_artifact(prep["imputer"], os.path.join(artifacts_dir, "imputer.pkl"))
    save_artifact(prep["scaler"], os.path.join(artifacts_dir, "scaler.pkl"))
    save_artifact(feature_mask, os.path.join(artifacts_dir, "feature_mask.pkl"))
    if rfe_selector is not None:
        save_artifact(rfe_selector, os.path.join(artifacts_dir, "rfe_selector.pkl"))

    # Save feature column order (needed for inference)
    save_artifact(list(X.columns), os.path.join(artifacts_dir, "feature_columns.pkl"))

    # 7. Train track-specific models
    if args.track == "thesis":
        results = run_thesis_track(cfg, X_train, X_test, y_train_bal, y_test_arr, artifacts_dir)
    else:
        results = run_requested_track(cfg, X_train, X_test, y_train_bal, y_test_arr, artifacts_dir)

    # 8. Print comparison table
    _, best_name = print_results_table(results)

    # 9. Save metrics CSV + performance plot
    save_metrics_csv(results, metrics_csv)
    save_performance_plot(results, plot_png)

    print(f"\n[train] Done. Artifacts saved in '{artifacts_dir}/'")


if __name__ == "__main__":
    main()
