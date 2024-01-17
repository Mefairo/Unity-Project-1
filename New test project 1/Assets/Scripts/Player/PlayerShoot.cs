using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : ShootSystem
{
    protected override void Update()
    {
        if (_timeBtwShots <= 0)
        {
            if (Input.GetMouseButton(0))
                Shoot();
        }

        else
            _timeBtwShots -= Time.deltaTime;
    }

    protected override void Shoot()
    {
        //Instantiate(_bullet, _shotPoint.position, _shotPoint.rotation, _bulletContainer);
        DoShot?.Invoke();
        _tester.pool.Get();

        _timeBtwShots = _startTimeBtwShots;
    }

}
