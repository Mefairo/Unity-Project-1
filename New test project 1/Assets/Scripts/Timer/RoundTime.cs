using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoundTime : MonoBehaviour
{
    [SerializeField] private int _countRound;
    [SerializeField] private TextMeshProUGUI _countRoundText;
    [SerializeField] private Timer _timer;

    public int CountRound => _countRound;

    public event Action NextRoundToStart;

    private void Awake()
    {
        _countRound = 1;
    }

    private void OnEnable()
    {
        _timer.TimeToUpStats += UpgradeUnits;
    }

    private void OnDisable()
    {
        _timer.TimeToUpStats -= UpgradeUnits;
    }

    private void UpgradeUnits()
    {
        Debug.Log("up");
        _countRound++;
        _countRoundText.text = $"Round {_countRound}";

        NextRoundToStart?.Invoke();
    }
}
