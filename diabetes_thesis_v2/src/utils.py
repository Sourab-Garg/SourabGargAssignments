"""Artifact persistence helpers (save/load models, preprocessors, etc.)."""

import os
import joblib


def ensure_artifacts_dir(path: str = "artifacts"):
    os.makedirs(path, exist_ok=True)


def save_artifact(obj, path: str):
    """Serialize any Python/sklearn object with joblib."""
    ensure_artifacts_dir(os.path.dirname(path) or ".")
    joblib.dump(obj, path)
    print(f"[utils] Saved → {path}")


def load_artifact(path: str):
    """Deserialize a joblib artifact."""
    if not os.path.exists(path):
        raise FileNotFoundError(f"Artifact not found: '{path}'. Run train.py first.")
    obj = joblib.load(path)
    print(f"[utils] Loaded ← {path}")
    return obj


def save_keras_model(model, path: str):
    """Save a Keras model to a directory (SavedModel format)."""
    ensure_artifacts_dir(os.path.dirname(path) or ".")
    model.save(path)
    print(f"[utils] Keras model saved → {path}")


def load_keras_model(path: str):
    """Load a Keras model from a SavedModel directory."""
    from tensorflow.keras.models import load_model  # lazy import

    if not os.path.exists(path):
        raise FileNotFoundError(f"Keras model not found: '{path}'. Run train.py first.")
    model = load_model(path)
    print(f"[utils] Keras model loaded ← {path}")
    return model


def load_config(path: str = "config.yaml") -> dict:
    """Load YAML configuration file.

    Parameters
    ----------
    path : str

    Returns
    -------
    dict
    """
    import yaml

    with open(path, "r") as fh:
        cfg = yaml.safe_load(fh)
    return cfg
