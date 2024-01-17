using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : UnitHealth
{
    [SerializeField] private int _points;

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
        Destroy(transform.parent.gameObject);
    }
}
