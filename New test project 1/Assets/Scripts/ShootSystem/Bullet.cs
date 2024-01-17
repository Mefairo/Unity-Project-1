using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Pool;

public class Bullet : MonoBehaviour, IPoolable<Bullet>
{
    [SerializeField] private UnitConfig _config;
    [SerializeField] private LayerMask _isSolidObject;

    [SerializeField] private float _lifetimeEnable;
    [SerializeField] private float _lifetimeDestroy;
    [SerializeField] private float _speed;
    [SerializeField] private float _damage;
    [SerializeField] private float _distance;

    [SerializeField] private Tester _tester;
    [SerializeField] private BulletType _bulletType;

    private ObjectPool<Bullet> _pool;

    private void Awake()
    {
        Initialize();
    }

    private void OnEnable()
    {
        StartCoroutine(DisableBulletByTime());
    }

    private void Start()
    {
        TypeBullet();
        StartCoroutine(DestroyBulletByTime());
    }

    private void Update()
    {
        MoveBullet();

        CheckCollision();
    }

    private void Initialize()
    {
        _damage = _config.Damage;
    }

    private void MoveBullet()
    {
        transform.Translate(Vector2.up * _speed * Time.deltaTime);
    }

    private void CheckCollision()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, _distance, _isSolidObject);

        if (hitInfo.collider != null)
            HandleCollision(hitInfo.collider);
    }

    private void HandleCollision(Collider2D collider)
    {
        if (collider.TryGetComponent(out IHealthChangeable damageable))
        {
            damageable.TakeDamage(_damage);
        }

        //Destroy(gameObject);
        //_pool.Release(this);
        _tester.pool.Release(this);
    }

    private IEnumerator DisableBulletByTime()
    {
        yield return new WaitForSeconds(_lifetimeEnable);

        //Destroy(gameObject);
        //_pool.Release(this);
        _tester.pool.Release(this);
    }

    private IEnumerator DestroyBulletByTime()
    {
        yield return new WaitForSeconds(_lifetimeDestroy);

        Destroy(gameObject);
    }

    public void SetPool(ObjectPool<Bullet> pool)
    {
        _pool = pool;
    }

    private void TypeBullet()
    {
        switch (_bulletType)
        {
            case BulletType.Player:
                _tester = FindObjectOfType<PlayerBulletPool>();
                break;

            case BulletType.Enemy:
                _tester = FindObjectOfType<EnemyBulletPool>();
                break;
        }
    }
}
