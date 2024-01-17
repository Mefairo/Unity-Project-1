using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Unit : MonoBehaviour
{
    [SerializeField] protected UnitConfig _unitConfig;

    public UnitConfig UnitConfig => _unitConfig;

}