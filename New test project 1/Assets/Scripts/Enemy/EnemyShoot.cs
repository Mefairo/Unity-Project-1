using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyShoot : ShootSystem
{
    protected override void Update()
    {
        if (_timeBtwShots <= 0)
            Shoot();

        else
            _timeBtwShots -= Time.deltaTime;
    }

    protected override void Shoot()
    {
        //Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation, _bulletContainer);
        _tester.pool.Get();
        DoShot?.Invoke();

        _timeBtwShots = _startTimeBtwShots;
    }
}
