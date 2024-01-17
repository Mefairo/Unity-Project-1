using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : UnitHealth
{
    [SerializeField] private LoadManager _loadManager;

    public override void TakeDamage(float damageValue)
    {
        CurrentHealth -= damageValue;

        CheckHealth(CurrentHealth);
    }

    public override void TakeHeal(float healValue)
    {
        _maxHealth += healValue;
        CurrentHealth += healValue;
    }

    protected override void CheckHealth(float health)
    {
        if (health <= 0)
            DestroyUnit();
    }

    protected override void DestroyUnit()
    {
        _loadManager.RestartGame();
        Destroy(gameObject);
    }
}
