"""Hybrid weighted ensemble for the thesis track (LR + RF + XGBoost)."""

import numpy as np


class HybridWeightedEnsemble:
    """Soft-voting ensemble that weights each model's predicted probability by its
    validation F1 score (or a user-supplied weight vector).

    Parameters
    ----------
    model_names : list[str]
        Ordered list of model identifiers.
    weights : list[float] | None
        If None, weights are learned via :py:meth:`fit_weights`.
        If provided, they are normalised and used directly.
    """

    def __init__(self, model_names: list, weights: list | None = None):
        self.model_names = model_names
        if weights is not None:
            w = np.asarray(weights, dtype=float)
            self.weights = w / w.sum()
        else:
            self.weights = None

    def fit_weights(self, val_f1_scores: dict):
        """Derive normalised weights from per-model validation F1 scores.

        Parameters
        ----------
        val_f1_scores : dict  – {model_name: f1_score}
        """
        scores = np.array([val_f1_scores[n] for n in self.model_names], dtype=float)
        self.weights = scores / scores.sum()
        print(
            "[ensemble] Computed weights from F1 scores: "
            + ", ".join(f"{n}={w:.4f}" for n, w in zip(self.model_names, self.weights))
        )

    def predict_proba(self, model_probas: dict) -> np.ndarray:
        """Weighted average of per-model class-1 probabilities.

        Parameters
        ----------
        model_probas : dict  – {model_name: np.ndarray of shape (n_samples,)}
            Class-1 probability for each model.

        Returns
        -------
        np.ndarray of shape (n_samples,)  – ensemble probability
        """
        if self.weights is None:
            raise RuntimeError("Weights not set. Call fit_weights() first.")

        weighted = np.zeros(len(next(iter(model_probas.values()))), dtype=float)
        for name, w in zip(self.model_names, self.weights):
            weighted += w * model_probas[name]
        return weighted

    def predict(self, model_probas: dict, threshold: float = 0.5) -> np.ndarray:
        """Return hard class predictions (0/1).

        Parameters
        ----------
        model_probas : dict
        threshold : float

        Returns
        -------
        np.ndarray[int]
        """
        proba = self.predict_proba(model_probas)
        return (proba >= threshold).astype(int)


def get_probas_from_sklearn(models: dict, X: np.ndarray) -> dict:
    """Helper to extract class-1 probabilities from a dict of sklearn-compatible models.

    Parameters
    ----------
    models : dict  – {name: fitted_model}
    X : np.ndarray – feature matrix

    Returns
    -------
    dict  – {name: proba_array}
    """
    return {name: model.predict_proba(X)[:, 1] for name, model in models.items()}
