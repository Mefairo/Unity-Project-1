using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class EnemyMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private EnemyUnits _enemyUnit;
    [SerializeField] private PlayerUnit _player;
    [SerializeField] private float _approachDistance;
    [SerializeField] private float _speed;
    [SerializeField] protected float _rotationSpeed;
    [SerializeField] protected float offset; 

    private float rotZ;
    private Vector3 difference;
    private Rigidbody2D _rbEnemy;

    public PlayerUnit Player => _player;

    private void Awake()
    {
        Initialize();

        _rbEnemy = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        _player = FindObjectOfType<PlayerUnit>();
    }

    private void FixedUpdate()
    {
        Move();
        //Turn();
    }

    private void Initialize()
    {
        _speed = _enemyUnit.UnitConfig.Speed;
    }

    public void Move()
    {
        var directionToPlayer = (_player.transform.position - transform.position).normalized;

        float distanceToPlayer = Vector3.Distance(transform.position, _player.transform.position);

        if (distanceToPlayer > _approachDistance)
        {
            var direction = (directionToPlayer).normalized;
            transform.Translate(direction * _speed * Time.deltaTime);
            //_rbEnemy.MovePosition(direction);
        }

        //float angle = Mathf.Atan2(directionToPlayer.y, directionToPlayer.x) * Mathf.Rad2Deg;
        //Quaternion targetRotation = Quaternion.Euler(new Vector3(0, 0, angle - 90f));
        //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, _rotationSpeed * Time.deltaTime);
    }

    private void Turn()
    {
        var difference = _player.transform.position - transform.position;
        var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);
    }
}
