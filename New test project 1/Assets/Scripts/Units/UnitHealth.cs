using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public abstract class UnitHealth : MonoBehaviour, IHealthChangeable
{
    [SerializeField] protected Unit _unit;
    [SerializeField] protected float _maxHealth;
    [SerializeField] protected float _currentHealth;
    [SerializeField] protected HealthBar _healthBar;

    public event Action<float> OnHealthChanged;

    public float MaxHealth => _maxHealth;


    public float CurrentHealth
    {
        get => _currentHealth;
        protected set
        {
            _currentHealth = Mathf.Clamp(value, 0f, _maxHealth);
            OnHealthChanged?.Invoke(_currentHealth);
        }
    }

    protected void Awake()
    {
        Initialize();
    }

    private void Initialize()
    {
        _maxHealth = _unit.UnitConfig.MaxHealth;
        CurrentHealth = _maxHealth;

        _healthBar?.SetMaxHealth(MaxHealth);
        _healthBar?.SetHealth(CurrentHealth);
    }

    public abstract void TakeDamage(float damageValue);
    public abstract void TakeHeal(float healValue);
    protected abstract void CheckHealth(float healthValue);
    protected abstract void DestroyUnit();
}
