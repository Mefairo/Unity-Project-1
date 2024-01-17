using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider _sliderHP;
    [SerializeField] private UnitHealth _unitHealth;
    [SerializeField] private TextMeshProUGUI _textHP;

    private void Awake()
    {
        _sliderHP = GetComponent<Slider>();
    }

    private void OnEnable()
    {
        _unitHealth.OnHealthChanged += SetHealth;
    }

    private void OnDisable()
    {
        _unitHealth.OnHealthChanged -= SetHealth;
    }

    public void SetHealth(float health)
    {
        _sliderHP.value = health;
        _textHP.text = health.ToString();
    }

    public void SetMaxHealth(float maxHealth)
    {
        _sliderHP.maxValue = maxHealth;
    }
}
