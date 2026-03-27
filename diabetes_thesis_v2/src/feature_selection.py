"""RFE-based feature selection."""

import numpy as np
from sklearn.feature_selection import RFE
from sklearn.linear_model import LogisticRegression


def select_features_rfe(
    X_train: np.ndarray,
    y_train: np.ndarray,
    X_test: np.ndarray,
    n_features: int = 6,
    random_state: int = 42,
):
    """Apply Recursive Feature Elimination (RFE) using Logistic Regression as estimator.

    Fitted on the (SMOTE-balanced) training set; the same mask is applied to the test set.

    Parameters
    ----------
    X_train : np.ndarray   – scaled, balanced training features
    y_train : np.ndarray   – balanced training labels
    X_test  : np.ndarray   – scaled test features
    n_features : int       – number of features to keep
    random_state : int

    Returns
    -------
    X_train_sel : np.ndarray
    X_test_sel  : np.ndarray
    feature_mask : np.ndarray[bool]  – which original feature columns were retained
    selector : fitted RFE object (for later inference)
    """
    estimator = LogisticRegression(max_iter=1000, random_state=random_state)
    selector = RFE(estimator=estimator, n_features_to_select=n_features)

    X_train_sel = selector.fit_transform(X_train, y_train)
    X_test_sel = selector.transform(X_test)
    feature_mask = selector.get_support()

    print(
        f"[feature_selection] RFE kept {n_features} of {X_train.shape[1]} features: "
        f"mask={feature_mask.astype(int).tolist()}"
    )
    return X_train_sel, X_test_sel, feature_mask, selector
