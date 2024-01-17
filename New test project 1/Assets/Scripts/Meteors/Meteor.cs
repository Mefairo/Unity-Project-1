using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Meteor : MonoBehaviour
{
    [SerializeField] private UnitConfig _config;
    [SerializeField] private float _lifetime;
    [SerializeField] private float _damage;
    [Space]
    [SerializeField] private LayerMask _targetLayer;

    public MoveMeteor _moveMeteor;

    public event Action OnMeteorDestroy;

    private void Awake()
    {
        Initialize();

        _moveMeteor = GetComponent<MoveMeteor>();
    }

    private void Start()
    {
        Invoke(nameof(DestroyMeteor), _lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if ((_targetLayer.value & (1 << collision.gameObject.layer)) > 0)
        {
            collision.gameObject.TryGetComponent(out IHealthChangeable health);

            health.TakeDamage(_damage);

            DestroyMeteor();
        }
    }

    private void Initialize()
    {
        _damage = _config.Damage;
    }

    private void DestroyMeteor()
    {
        OnMeteorDestroy?.Invoke();
        Destroy(gameObject);
    }
}
