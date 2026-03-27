# Diabetes Thesis v2 – Early Diabetes Prediction System

A complete, modular Python ML project implementing the thesis-described pipeline for early diabetes prediction using the PIMA Indians Diabetes Dataset.

---

## Project Structure

```
diabetes_thesis_v2/
├── README.md
├── requirements.txt
├── config.yaml              # all hyper-parameters, paths, and flags
├── train.py                 # main training entry point
├── predict.py               # inference entry point (loads artifacts)
├── sample_patient.json      # example patient record for quick testing
├── .gitignore
├── artifacts/               # generated at runtime (models, preprocessors, plots)
└── src/
    ├── __init__.py
    ├── data.py              # data loading & validation
    ├── preprocessing.py     # zeros→NaN, imputation, scaling, SMOTE
    ├── feature_selection.py # RFE feature selection
    ├── models.py            # LR, RF, XGBoost, KNN, DNN trainers
    ├── evaluate.py          # metrics, results table, bar-chart plot
    ├── ensemble.py          # hybrid weighted ensemble
    └── utils.py             # artifact save/load helpers
```

---

## Setup

```bash
# 1. Create a virtual environment (recommended)
python -m venv .venv
source .venv/bin/activate      # Windows: .venv\Scripts\activate

# 2. Install dependencies
pip install -r requirements.txt
```

---

## Data

Download the **PIMA Indians Diabetes Dataset** (e.g. from [Kaggle](https://www.kaggle.com/datasets/uciml/pima-indians-diabetes-database)) and save it as `diabetes.csv` in the `diabetes_thesis_v2/` directory.

### Expected CSV columns

| Column | Description |
|---|---|
| Pregnancies | Number of pregnancies |
| Glucose | Plasma glucose concentration (2-hour oral glucose tolerance test) |
| BloodPressure | Diastolic blood pressure (mm Hg) |
| SkinThickness | Triceps skinfold thickness (mm) |
| Insulin | 2-hour serum insulin (µU/mL) |
| BMI | Body mass index (weight kg / height m²) |
| DiabetesPedigreeFunction | Diabetes pedigree function score |
| Age | Age in years |
| Outcome | 0 = Non-diabetic, 1 = Diabetic (target) |

---

## Running the System

### Training

**Thesis track** – Logistic Regression + Random Forest + tuned XGBoost + hybrid weighted ensemble:
```bash
python train.py --track thesis
```

**Requested track** – tuned XGBoost + tuned KNN + DNN:
```bash
python train.py --track requested
```

Both commands will:
1. Load and preprocess `diabetes.csv`
2. Apply stratified 80/20 split
3. Impute missing values (median), apply StandardScaler, SMOTE
4. Optionally select top-6 features via RFE
5. Train and tune each model
6. Print a comparison table (Accuracy / Precision / Recall / F1)
7. Save all artifacts to `artifacts/`
8. Save `artifacts/metrics.csv` and `artifacts/performance_plot.png`

### Inference

After training, run predictions from `sample_patient.json`:
```bash
# Thesis track – hybrid ensemble probability
python predict.py --track thesis --patient sample_patient.json

# Requested track – best available model
python predict.py --track requested --patient sample_patient.json

# Inline JSON
python predict.py --track thesis --inline '{"Pregnancies":2,"Glucose":130,"BloodPressure":70,"SkinThickness":25,"Insulin":94,"BMI":28.5,"DiabetesPedigreeFunction":0.35,"Age":35}'
```

---

## Configuration

All settings are centralised in `config.yaml`. Key options:

```yaml
data:
  path: "diabetes.csv"
  test_size: 0.20
  random_state: 42

preprocessing:
  imputation_strategy: "median"
  use_smote: true

feature_selection:
  enabled: true
  n_features: 6

models:
  xgboost:
    param_grid:
      n_estimators: [100, 200]
      max_depth: [3, 5]
      ...
```

---

## Expected Output (illustrative)

```
[train] Track: THESIS

[preprocess] Replaced 5 zeros with NaN in 'Glucose'
...
[preprocess] SMOTE applied: {0: 417, 1: 217} → {0: 417, 1: 417}
[feature_selection] RFE kept 6 of 8 features

[models] Logistic Regression trained
[models] Random Forest trained
[models] XGBoost tuned – best params: {'colsample_bytree': 1.0, 'learning_rate': 0.1, ...}
[ensemble] Computed weights from F1 scores: LR=0.31, RF=0.35, XGBoost=0.34

=======================================================
           MODEL COMPARISON (sorted by F1)
=======================================================
   Model  Accuracy  Precision  Recall      F1
Ensemble    0.8117     0.7419  0.7419  0.7419
       RF   0.7987     0.7234  0.7288  0.7261
 XGBoost   0.8052     0.7321  0.7068  0.7193
      LR   0.7727     0.6842  0.7123  0.6980

>>> Best model by F1: Ensemble (0.7419)
```

---

## Preprocessing Pipeline

```
Raw CSV
  │
  ├─ Replace 0→NaN (Glucose, BloodPressure, SkinThickness, Insulin, BMI)
  │
  ├─ Stratified 80/20 train-test split
  │
  ├─ Median imputation (fit on train only)
  ├─ StandardScaler (fit on train only)
  ├─ SMOTE oversampling (train only)
  │
  └─ RFE feature selection (optional, configurable)
```

---

## Models

| Track | Models | Tuning |
|---|---|---|
| thesis | Logistic Regression, Random Forest, XGBoost | GridSearchCV for XGBoost |
| requested | XGBoost, KNN, DNN (Keras) | GridSearchCV for XGBoost & KNN |

The **thesis track** also builds a **hybrid weighted ensemble** where each component model's weight is proportional to its validation F1 score.

---

## Artifacts Generated

| File | Description |
|---|---|
| `artifacts/imputer.pkl` | Fitted SimpleImputer |
| `artifacts/scaler.pkl` | Fitted StandardScaler |
| `artifacts/feature_mask.pkl` | Boolean mask from RFE |
| `artifacts/rfe_selector.pkl` | Fitted RFE selector |
| `artifacts/feature_columns.pkl` | Ordered feature column names |
| `artifacts/model_lr.pkl` | Trained Logistic Regression (thesis) |
| `artifacts/model_rf.pkl` | Trained Random Forest (thesis) |
| `artifacts/model_xgboost.pkl` | Tuned XGBoost |
| `artifacts/model_knn.pkl` | Tuned KNN (requested) |
| `artifacts/model_dnn/` | Saved Keras DNN (requested) |
| `artifacts/ensemble.pkl` | Hybrid ensemble with weights (thesis) |
| `artifacts/metrics.csv` | Model comparison table |
| `artifacts/performance_plot.png` | Bar chart of Accuracy/Precision/Recall/F1 |
