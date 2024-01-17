using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class MoveMeteor : MonoBehaviour
{
    [SerializeField] private UnitConfig _config;
    [SerializeField] private float _speed;

    private Vector3 _moveDirection;

    private void Awake()
    {
        Initialize();
    }

    private void FixedUpdate()
    {
        transform.Translate(_moveDirection * _speed * Time.deltaTime);
    }

    private void Initialize()
    {
        _speed = _config.Speed;
    }

    public void MoveAfterSplit()
    {
        float randomAngle = Random.Range(0f, 2f * Mathf.PI);

        _moveDirection = new Vector2(Mathf.Cos(randomAngle), Mathf.Sin(randomAngle));
        _moveDirection.Normalize();
    }

    public void MoveDirection(Vector3 direction)
    {
        _moveDirection = direction;
        _moveDirection.Normalize();
    }
}
