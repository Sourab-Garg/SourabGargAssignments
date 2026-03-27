"""Preprocessing pipeline: zero replacement, imputation, scaling, SMOTE."""

import numpy as np
import pandas as pd
from sklearn.impute import SimpleImputer
from sklearn.preprocessing import StandardScaler
from sklearn.model_selection import train_test_split
from imblearn.over_sampling import SMOTE

# Columns where physiological zero is impossible and must be treated as missing
ZERO_INVALID_COLS = [
    "Glucose",
    "BloodPressure",
    "SkinThickness",
    "Insulin",
    "BMI",
]


def replace_invalid_zeros(df: pd.DataFrame, cols: list | None = None) -> pd.DataFrame:
    """Replace 0 with NaN in clinically invalid columns.

    Parameters
    ----------
    df : pd.DataFrame
    cols : list | None
        Columns to process; defaults to ZERO_INVALID_COLS.

    Returns
    -------
    pd.DataFrame
        Copy of df with zeros replaced by NaN in specified columns.
    """
    if cols is None:
        cols = ZERO_INVALID_COLS

    df = df.copy()
    for col in cols:
        if col in df.columns:
            n_zeros = (df[col] == 0).sum()
            df[col] = df[col].replace(0, np.nan)
            print(f"[preprocess] Replaced {n_zeros} zeros with NaN in '{col}'")
    return df


def stratified_split(X, y, test_size: float = 0.20, random_state: int = 42):
    """Stratified 80/20 train-test split.

    Returns
    -------
    tuple: X_train_df, X_test_df, y_train, y_test
    """
    X_train, X_test, y_train, y_test = train_test_split(
        X, y,
        test_size=test_size,
        stratify=y,
        random_state=random_state,
    )
    print(
        f"[preprocess] Train: {len(X_train)} rows | Test: {len(X_test)} rows "
        f"(stratified, test_size={test_size})"
    )
    return X_train, X_test, y_train, y_test


def build_preprocessor(
    X_train: pd.DataFrame,
    X_test: pd.DataFrame,
    y_train,
    imputation_strategy: str = "median",
    use_smote: bool = True,
    smote_random_state: int = 42,
):
    """Fit imputer and scaler on train split, transform both splits, apply SMOTE to train.

    Parameters
    ----------
    X_train, X_test : pd.DataFrame
    y_train : pd.Series or np.ndarray
    imputation_strategy : str
        'median' or 'mean'
    use_smote : bool
        Whether to apply SMOTE oversampling on the training set.
    smote_random_state : int

    Returns
    -------
    dict with keys:
        X_train_bal, X_test_scaled, y_train_bal,
        imputer, scaler
    """
    # 1. Imputation (fit on train only)
    imputer = SimpleImputer(strategy=imputation_strategy)
    X_train_imp = imputer.fit_transform(X_train)
    X_test_imp = imputer.transform(X_test)
    print(f"[preprocess] Imputer fitted (strategy='{imputation_strategy}')")

    # 2. Scaling (fit on train only)
    scaler = StandardScaler()
    X_train_scaled = scaler.fit_transform(X_train_imp)
    X_test_scaled = scaler.transform(X_test_imp)
    print("[preprocess] StandardScaler fitted and applied")

    # 3. SMOTE on training set only
    if use_smote:
        smote = SMOTE(random_state=smote_random_state)
        X_train_bal, y_train_bal = smote.fit_resample(X_train_scaled, y_train)
        before = dict(zip(*np.unique(y_train, return_counts=True)))
        after = dict(zip(*np.unique(y_train_bal, return_counts=True)))
        print(f"[preprocess] SMOTE applied: {before} → {after}")
    else:
        X_train_bal = X_train_scaled
        y_train_bal = np.asarray(y_train)
        print("[preprocess] SMOTE skipped (use_smote=False)")

    return {
        "X_train_bal": X_train_bal,
        "X_test_scaled": X_test_scaled,
        "y_train_bal": y_train_bal,
        "imputer": imputer,
        "scaler": scaler,
    }
