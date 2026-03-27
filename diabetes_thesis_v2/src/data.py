"""Data loading utilities for the diabetes prediction system."""

import pandas as pd


# Expected PIMA-like column set
EXPECTED_COLUMNS = [
    "Pregnancies",
    "Glucose",
    "BloodPressure",
    "SkinThickness",
    "Insulin",
    "BMI",
    "DiabetesPedigreeFunction",
    "Age",
    "Outcome",
]


def load_data(path: str) -> pd.DataFrame:
    """Load the diabetes CSV dataset.

    Parameters
    ----------
    path : str
        Path to the CSV file (PIMA-like format).

    Returns
    -------
    pd.DataFrame
        Raw dataframe.

    Raises
    ------
    FileNotFoundError
        If the CSV file does not exist.
    ValueError
        If required columns are missing.
    """
    try:
        df = pd.read_csv(path)
    except FileNotFoundError:
        raise FileNotFoundError(
            f"Dataset not found at '{path}'. "
            "Download the PIMA Indians Diabetes dataset (e.g. from Kaggle) "
            "and save it as 'diabetes.csv' in the project root."
        )

    missing = [c for c in EXPECTED_COLUMNS if c not in df.columns]
    if missing:
        raise ValueError(
            f"The following expected columns are missing from the dataset: {missing}"
        )

    print(f"[data] Loaded {len(df)} rows × {len(df.columns)} columns from '{path}'")
    return df


def split_features_target(df: pd.DataFrame, target_col: str = "Outcome"):
    """Separate features (X) and target (y).

    Parameters
    ----------
    df : pd.DataFrame
    target_col : str

    Returns
    -------
    tuple[pd.DataFrame, pd.Series]
    """
    X = df.drop(columns=[target_col])
    y = df[target_col]
    return X, y
