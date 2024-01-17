using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Timer : MonoBehaviour
{
    [SerializeField] private float _totalTime;
    [SerializeField] private TextMeshProUGUI _timerText;
    [SerializeField] private float _timeToUp;

    private float _currentTime;
    private int _minutes;
    private int _seconds;

    private bool _timerActive = false;

    public event Action TimeToUpStats;

    private void Start()
    {
        StartTimer();
        InvokeRepeating(nameof(TimeToUpgrade), _timeToUp, _timeToUp);
    }

    public void StartTimer()
    {
        _timerActive = true;
        _currentTime = _totalTime;

        StartCoroutine(RoundTimerCoroutine());

        UpdateUIText();
    }

    private void UpdateUIText()
    {
        _minutes = Mathf.FloorToInt(_currentTime / 60);
        _seconds = Mathf.FloorToInt(_currentTime % 60);

        _timerText.text = string.Format("{0:00}:{1:00}", _minutes, _seconds);
    }

    private void EndRound()
    {
        _timerActive = false;

        CancelInvoke(nameof(TimeToUpgrade));
    }

    private IEnumerator RoundTimerCoroutine()
    {

        while (_currentTime > 0.1 && _timerActive)
        {
            _currentTime += Time.deltaTime;

            UpdateUIText();

            yield return null;
        }

        _currentTime = 0;
        UpdateUIText();
        EndRound();

        yield return null;
    }

    private void TimeToUpgrade()
    {
        TimeToUpStats?.Invoke();
    }
}
