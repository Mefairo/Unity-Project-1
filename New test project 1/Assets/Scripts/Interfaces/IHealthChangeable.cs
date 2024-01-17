using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IHealthChangeable
{
    public void TakeDamage(float damageValue);

    public void TakeHeal(float healValue);
}
