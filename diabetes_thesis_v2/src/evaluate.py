"""Evaluation metrics, results table, and performance plot."""

import os
import numpy as np
import pandas as pd
import matplotlib
matplotlib.use("Agg")           # non-interactive backend for CI/headless use
import matplotlib.pyplot as plt
from sklearn.metrics import (
    accuracy_score,
    precision_score,
    recall_score,
    f1_score,
    confusion_matrix,
    classification_report,
)


def evaluate_model(y_true: np.ndarray, y_pred: np.ndarray) -> dict:
    """Compute classification metrics for a single model.

    Returns
    -------
    dict with keys: Accuracy, Precision, Recall, F1, ConfusionMatrix
    """
    return {
        "Accuracy":        accuracy_score(y_true, y_pred),
        "Precision":       precision_score(y_true, y_pred, zero_division=0),
        "Recall":          recall_score(y_true, y_pred, zero_division=0),
        "F1":              f1_score(y_true, y_pred, zero_division=0),
        "ConfusionMatrix": confusion_matrix(y_true, y_pred),
    }


def print_results_table(results: dict):
    """Print a sorted comparison table and per-model confusion matrices."""
    rows = []
    for name, m in results.items():
        rows.append({
            "Model":     name,
            "Accuracy":  round(m["Accuracy"],  4),
            "Precision": round(m["Precision"], 4),
            "Recall":    round(m["Recall"],    4),
            "F1":        round(m["F1"],        4),
        })

    table = (
        pd.DataFrame(rows)
        .sort_values(by="F1", ascending=False)
        .reset_index(drop=True)
    )

    print("\n" + "=" * 55)
    print("           MODEL COMPARISON (sorted by F1)")
    print("=" * 55)
    print(table.to_string(index=False))

    for name, m in results.items():
        print(f"\n[{name}] Confusion Matrix:")
        cm = m["ConfusionMatrix"]
        print(f"  TN={cm[0,0]}  FP={cm[0,1]}")
        print(f"  FN={cm[1,0]}  TP={cm[1,1]}")

    best = table.iloc[0]["Model"]
    print(f"\n>>> Best model by F1: {best} ({table.iloc[0]['F1']:.4f})")
    return table, best


def save_metrics_csv(results: dict, path: str):
    """Save the metrics comparison table to a CSV file."""
    os.makedirs(os.path.dirname(path) or ".", exist_ok=True)
    rows = []
    for name, m in results.items():
        rows.append({
            "Model":     name,
            "Accuracy":  round(m["Accuracy"],  4),
            "Precision": round(m["Precision"], 4),
            "Recall":    round(m["Recall"],    4),
            "F1":        round(m["F1"],        4),
        })
    pd.DataFrame(rows).to_csv(path, index=False)
    print(f"[evaluate] Metrics saved → {path}")


def save_performance_plot(results: dict, path: str):
    """Save a grouped bar chart of Accuracy/Precision/Recall/F1 per model."""
    os.makedirs(os.path.dirname(path) or ".", exist_ok=True)

    metrics = ["Accuracy", "Precision", "Recall", "F1"]
    model_names = list(results.keys())
    data = np.array([[results[m][k] for k in metrics] for m in model_names])

    x = np.arange(len(model_names))
    width = 0.18
    offsets = np.linspace(-(len(metrics) - 1) / 2, (len(metrics) - 1) / 2, len(metrics)) * width

    fig, ax = plt.subplots(figsize=(max(8, len(model_names) * 2), 5))
    colors = ["#4C72B0", "#DD8452", "#55A868", "#C44E52"]
    for i, (metric, offset, color) in enumerate(zip(metrics, offsets, colors)):
        bars = ax.bar(x + offset, data[:, i], width=width, label=metric, color=color)
        for bar in bars:
            ax.text(
                bar.get_x() + bar.get_width() / 2,
                bar.get_height() + 0.005,
                f"{bar.get_height():.2f}",
                ha="center", va="bottom", fontsize=7,
            )

    ax.set_xticks(x)
    ax.set_xticklabels(model_names, fontsize=10)
    ax.set_ylim(0, 1.10)
    ax.set_ylabel("Score")
    ax.set_title("Model Performance Comparison")
    ax.legend(loc="lower right")
    ax.grid(axis="y", linestyle="--", alpha=0.5)
    fig.tight_layout()
    fig.savefig(path, dpi=150)
    plt.close(fig)
    print(f"[evaluate] Performance plot saved → {path}")
