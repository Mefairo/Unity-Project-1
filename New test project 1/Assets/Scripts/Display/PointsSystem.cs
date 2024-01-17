using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PointsSystem : MonoBehaviour
{
    public static PointsSystem Instance;

    [SerializeField] private int _currentPoints;
    [SerializeField] private PlayerHealth _playerHP;

    public event Action<int> OnChangePoints;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            return;
        }

        else
            Destroy(gameObject);
    }

    public int CurrentPoints
    {
        get => _currentPoints;
        private set
        {
            _currentPoints = value;
            OnChangePoints?.Invoke(_currentPoints);
        }
    }

    public void UpdateScore(int score)
    {
        CurrentPoints += score;
        _playerHP.TakeHeal(score);

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CurrentPoints++;
        }
    }

}
