"""
predict.py – Load saved artifacts and predict from a JSON patient record.

Usage
-----
Thesis track (ensemble prediction):
    python predict.py --track thesis --patient sample_patient.json

Requested track (best model by F1):
    python predict.py --track requested --patient sample_patient.json

Custom patient inline:
    python predict.py --track thesis --inline '{"Pregnancies":2,"Glucose":130,"BloodPressure":70,
        "SkinThickness":25,"Insulin":94,"BMI":28.5,"DiabetesPedigreeFunction":0.35,"Age":35}'
"""

import argparse
import json
import os
import sys
import warnings

import numpy as np
import pandas as pd

warnings.filterwarnings("ignore")

sys.path.insert(0, os.path.dirname(__file__))

from src.utils import load_artifact, load_keras_model, load_config


# ---------------------------------------------------------------------------
# Helpers
# ---------------------------------------------------------------------------

def _parse_args():
    parser = argparse.ArgumentParser(description="Diabetes Thesis v2 – Inference")
    parser.add_argument(
        "--track",
        choices=["thesis", "requested"],
        default="thesis",
        help="Which saved artifacts to use for prediction",
    )
    parser.add_argument(
        "--patient",
        default="sample_patient.json",
        help="Path to JSON file with patient features",
    )
    parser.add_argument(
        "--inline",
        default=None,
        help="JSON string of patient features (overrides --patient)",
    )
    parser.add_argument(
        "--config",
        default="config.yaml",
        help="Path to config.yaml",
    )
    return parser.parse_args()


def _load_patient(args) -> dict:
    if args.inline:
        try:
            return json.loads(args.inline)
        except json.JSONDecodeError as exc:
            raise ValueError(f"Invalid --inline JSON: {exc}") from exc

    with open(args.patient, "r") as fh:
        return json.load(fh)


def _preprocess_patient(patient_dict: dict, feature_columns: list, imputer, scaler) -> np.ndarray:
    """Apply imputer + scaler to a single patient record."""
    # Build a 1-row DataFrame in the same column order used during training
    try:
        row = pd.DataFrame([[patient_dict[col] for col in feature_columns]], columns=feature_columns)
    except KeyError as exc:
        raise KeyError(
            f"Patient JSON is missing feature column: {exc}. "
            f"Required columns: {feature_columns}"
        ) from exc

    x_imp = imputer.transform(row)
    x_scaled = scaler.transform(x_imp)
    return x_scaled


# ---------------------------------------------------------------------------
# Track-specific prediction
# ---------------------------------------------------------------------------

def predict_thesis(artifacts_dir: str, x_scaled: np.ndarray, feature_mask):
    """Thesis track: hybrid ensemble (LR + RF + XGBoost)."""
    if feature_mask is not None:
        x = x_scaled[:, feature_mask]
    else:
        x = x_scaled

    lr = load_artifact(os.path.join(artifacts_dir, "model_lr.pkl"))
    rf = load_artifact(os.path.join(artifacts_dir, "model_rf.pkl"))
    xgb = load_artifact(os.path.join(artifacts_dir, "model_xgboost.pkl"))
    ensemble = load_artifact(os.path.join(artifacts_dir, "ensemble.pkl"))

    probas = {
        "LR":      lr.predict_proba(x)[:, 1],
        "RF":      rf.predict_proba(x)[:, 1],
        "XGBoost": xgb.predict_proba(x)[:, 1],
    }
    prob = float(ensemble.predict_proba(probas)[0])
    pred = int(prob >= 0.5)
    return pred, prob


def predict_requested(artifacts_dir: str, x_scaled: np.ndarray, feature_mask):
    """Requested track: use the best available model (prefer DNN if available)."""
    if feature_mask is not None:
        x = x_scaled[:, feature_mask]
    else:
        x = x_scaled

    # Load all models and pick best by whatever is available
    model_files = {
        "XGBoost": os.path.join(artifacts_dir, "model_xgboost.pkl"),
        "KNN":     os.path.join(artifacts_dir, "model_knn.pkl"),
        "DNN":     os.path.join(artifacts_dir, "model_dnn"),
    }

    # Prefer DNN → XGBoost → KNN (arbitrary; user can change)
    for name in ["DNN", "XGBoost", "KNN"]:
        path = model_files[name]
        if os.path.exists(path):
            if name == "DNN":
                model = load_keras_model(path)
                prob = float(model.predict(x, verbose=0)[0][0])
            else:
                model = load_artifact(path)
                prob = float(model.predict_proba(x)[0][1])
            pred = int(prob >= 0.5)
            return pred, prob, name

    raise FileNotFoundError(
        "No requested-track model artifacts found. Run: python train.py --track requested"
    )


# ---------------------------------------------------------------------------
# Main
# ---------------------------------------------------------------------------

def main():
    args = _parse_args()

    cfg = load_config(args.config)
    artifacts_dir = cfg.get("artifacts", {}).get("dir", "artifacts")

    # Load patient
    patient = _load_patient(args)
    print(f"\n[predict] Patient data: {patient}")

    # Load preprocessors
    imputer = load_artifact(os.path.join(artifacts_dir, "imputer.pkl"))
    scaler = load_artifact(os.path.join(artifacts_dir, "scaler.pkl"))
    feature_columns = load_artifact(os.path.join(artifacts_dir, "feature_columns.pkl"))
    feature_mask_path = os.path.join(artifacts_dir, "feature_mask.pkl")
    feature_mask = load_artifact(feature_mask_path) if os.path.exists(feature_mask_path) else None

    # Preprocess
    x_scaled = _preprocess_patient(patient, feature_columns, imputer, scaler)

    # Predict
    if args.track == "thesis":
        pred, prob = predict_thesis(artifacts_dir, x_scaled, feature_mask)
        model_used = "Ensemble (LR + RF + XGBoost)"
    else:
        pred, prob, model_used = predict_requested(artifacts_dir, x_scaled, feature_mask)

    label = "Diabetic" if pred == 1 else "Non-diabetic"
    print(f"\n[predict] Model used   : {model_used}")
    print(f"[predict] Predicted    : {pred} ({label})")
    print(f"[predict] Probability  : {prob:.4f}")
    print()


if __name__ == "__main__":
    main()
