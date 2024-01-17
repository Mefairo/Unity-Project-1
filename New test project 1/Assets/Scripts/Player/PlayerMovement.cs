using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour, IMoveable
{
    [SerializeField] private PlayerUnit _playerConfig;

    [SerializeField] private float moveSpeed;
    [SerializeField] private float offset;

    private Vector2 _moveInput;
    private Vector2 _moveVelocity;

    private Vector2 _difference;
    private float _rotZ;

    private Rigidbody2D _rbPlayer;
    private Camera _camera;

    private void Awake()
    {
        _rbPlayer = GetComponent<Rigidbody2D>();
        _camera = Camera.main;

        Initialize();
    }

    private void Update()
    {
        Move();
    }

    private void FixedUpdate()
    {
        _rbPlayer.MovePosition(_rbPlayer.position + _moveVelocity * Time.deltaTime);
    }

    private void Initialize()
    {
        moveSpeed = _playerConfig.UnitConfig.Speed;
    }

    public void Move()
    {
        _moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _moveVelocity = _moveInput.normalized * moveSpeed;

        _difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        _rotZ = Mathf.Atan2(_difference.y, _difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _rotZ + offset);
    }
}
