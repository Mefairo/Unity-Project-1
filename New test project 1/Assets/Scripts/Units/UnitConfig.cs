using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Source/Units/Config", fileName = "UnitConfig", order = 0)]
public class UnitConfig : ScriptableObject
{
    [Header("Name"), Space]

    [SerializeField] private string _unitName;

    [Header("Parametres"), Space]

    [SerializeField] private float _maxHealth;
    [SerializeField] private float _damage;
    [SerializeField] private float _speed;


    public string UnitName => _unitName;
    public float MaxHealth => _maxHealth;
    public float Damage => _damage;
    public float Speed => _speed;
}
