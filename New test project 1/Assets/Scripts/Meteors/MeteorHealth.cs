using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class MeteorHealth : UnitHealth
{
    [SerializeField] private int _points;

    public event Action MeteorDestroyed;

    public override void TakeDamage(float damageValue)
    {
        CurrentHealth -= damageValue;
        CheckHealth(CurrentHealth);
    }

    public override void TakeHeal(float healValue)
    {
        CurrentHealth += healValue;
    }

    protected override void CheckHealth(float health)
    {
        if (health <= 0)
            DestroyUnit();
    }

    protected override void DestroyUnit()
    {
        PointsSystem.Instance.UpdateScore(_points);
        MeteorDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
