using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour
{
    [SerializeField] private PointsSystem _pointSystem;
    [SerializeField] private TextMeshProUGUI _pointText;

    private void OnEnable()
    {
        _pointSystem.OnChangePoints += UpdateDisplayScore;
    }

    private void OnDisable()
    {
        _pointSystem.OnChangePoints -= UpdateDisplayScore;
    }

    private void UpdateDisplayScore(int scorePoint)
    {
        _pointText.text = $"Points: {scorePoint}";
    }
}
