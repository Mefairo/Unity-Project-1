using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ShootSystem : MonoBehaviour
{
    [SerializeField] protected Bullet _bullet;
    [SerializeField] protected Transform _shotPoint;
    [SerializeField] protected Transform _bulletContainer;

    [SerializeField] protected float _startTimeBtwShots;
    [SerializeField] private float _timeReload;

    protected float _timeBtwShots;
    protected Tester _tester;

    public Bullet Bullet => _bullet;
    public Transform ShotPoint => _shotPoint;
    public Transform BulletContainer => _bulletContainer;

    public  UnityAction DoShot;

    protected void Awake()
    {
        _tester = GetComponent<Tester>();
    }

    protected virtual void Update()
    {
        if (_timeBtwShots <= 0)
            Shoot();

        else
            _timeBtwShots -= Time.deltaTime;
    }

    protected virtual void Shoot()
    {
        //Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation, _bulletContainer);
        //_bulletSpawner.pool.Get();
        _tester.pool.Get();
        DoShot?.Invoke();

        _timeBtwShots = _startTimeBtwShots;
    }
}
