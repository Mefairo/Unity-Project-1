using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public abstract class Tester : MonoBehaviour
{
    public PoolTestMy<Bullet> bullet;

    public ObjectPool<Bullet> pool;

    protected void Start()
    {
        pool = new ObjectPool<Bullet>(bullet.CreateObject, bullet.OnTakeObjectFromPool, bullet.OnReturnObjectToPull, bullet.OnDestroyObject, true, 100, 1000);
    }
}
