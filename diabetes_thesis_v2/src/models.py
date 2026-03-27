"""Model builders and trainers for both thesis and requested tracks."""

import warnings
import numpy as np
from sklearn.linear_model import LogisticRegression
from sklearn.ensemble import RandomForestClassifier
from sklearn.neighbors import KNeighborsClassifier
from sklearn.model_selection import GridSearchCV
from xgboost import XGBClassifier


# ---------------------------------------------------------------------------
# Thesis track models
# ---------------------------------------------------------------------------

def train_logistic_regression(X_train: np.ndarray, y_train: np.ndarray, random_state: int = 42):
    """Logistic Regression (thesis track)."""
    model = LogisticRegression(max_iter=1000, random_state=random_state)
    model.fit(X_train, y_train)
    print("[models] Logistic Regression trained")
    return model


def train_random_forest(
    X_train: np.ndarray,
    y_train: np.ndarray,
    n_estimators: int = 200,
    max_depth: int = 10,
    random_state: int = 42,
):
    """Random Forest (thesis track)."""
    model = RandomForestClassifier(
        n_estimators=n_estimators,
        max_depth=max_depth,
        random_state=random_state,
        n_jobs=-1,
    )
    model.fit(X_train, y_train)
    print(f"[models] Random Forest trained (n_estimators={n_estimators}, max_depth={max_depth})")
    return model


def train_xgboost_tuned(
    X_train: np.ndarray,
    y_train: np.ndarray,
    param_grid: dict | None = None,
    cv: int = 5,
    scoring: str = "f1",
    random_state: int = 42,
):
    """Tuned XGBoost via GridSearchCV (used in both tracks)."""
    if param_grid is None:
        param_grid = {
            "n_estimators": [100, 200],
            "max_depth": [3, 5],
            "learning_rate": [0.05, 0.1],
            "subsample": [0.8, 1.0],
            "colsample_bytree": [0.8, 1.0],
        }

    base = XGBClassifier(
        objective="binary:logistic",
        eval_metric="logloss",
        random_state=random_state,
        verbosity=0,
    )
    grid = GridSearchCV(
        estimator=base,
        param_grid=param_grid,
        scoring=scoring,
        cv=cv,
        n_jobs=-1,
        verbose=0,
    )
    grid.fit(X_train, y_train)
    print(f"[models] XGBoost tuned – best params: {grid.best_params_}")
    return grid.best_estimator_, grid.best_params_


# ---------------------------------------------------------------------------
# Requested track models
# ---------------------------------------------------------------------------

def train_knn_tuned(
    X_train: np.ndarray,
    y_train: np.ndarray,
    param_grid: dict | None = None,
    cv: int = 5,
    scoring: str = "f1",
):
    """Tuned KNN via GridSearchCV (requested track)."""
    if param_grid is None:
        param_grid = {
            "n_neighbors": [3, 5, 7, 9, 11],
            "weights": ["uniform", "distance"],
            "metric": ["euclidean", "manhattan"],
        }

    grid = GridSearchCV(
        estimator=KNeighborsClassifier(),
        param_grid=param_grid,
        scoring=scoring,
        cv=cv,
        n_jobs=-1,
        verbose=0,
    )
    grid.fit(X_train, y_train)
    print(f"[models] KNN tuned – best params: {grid.best_params_}")
    return grid.best_estimator_, grid.best_params_


def train_dnn(
    X_train: np.ndarray,
    y_train: np.ndarray,
    hidden_layers: list | None = None,
    dropout_rate: float = 0.2,
    epochs: int = 150,
    batch_size: int = 32,
    validation_split: float = 0.2,
    patience: int = 15,
    random_state: int = 42,
):
    """Deep Neural Network (requested track) using TensorFlow/Keras.

    Returns
    -------
    model : trained Keras model
    history : training history
    """
    # import here so TF is only required when DNN track is used
    import tensorflow as tf
    from tensorflow.keras.models import Sequential
    from tensorflow.keras.layers import Dense, Dropout, BatchNormalization
    from tensorflow.keras.callbacks import EarlyStopping

    if hidden_layers is None:
        hidden_layers = [64, 32, 16]

    tf.random.set_seed(random_state)
    np.random.seed(random_state)

    input_dim = X_train.shape[1]

    model = Sequential()
    model.add(Dense(hidden_layers[0], activation="relu", input_shape=(input_dim,)))
    model.add(BatchNormalization())
    model.add(Dropout(dropout_rate))

    for units in hidden_layers[1:]:
        model.add(Dense(units, activation="relu"))
        model.add(BatchNormalization())
        model.add(Dropout(dropout_rate))

    model.add(Dense(1, activation="sigmoid"))

    model.compile(
        optimizer="adam",
        loss="binary_crossentropy",
        metrics=["accuracy"],
    )

    early_stop = EarlyStopping(
        monitor="val_loss",
        patience=patience,
        restore_best_weights=True,
    )

    with warnings.catch_warnings():
        warnings.simplefilter("ignore")
        history = model.fit(
            X_train,
            y_train,
            validation_split=validation_split,
            epochs=epochs,
            batch_size=batch_size,
            verbose=0,
            callbacks=[early_stop],
        )

    stopped_epoch = early_stop.stopped_epoch or epochs
    print(f"[models] DNN trained – stopped at epoch {stopped_epoch}")
    return model, history
