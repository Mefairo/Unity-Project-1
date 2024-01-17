using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    [Header("Coordinates")]
    [SerializeField] private float _endX;
    [SerializeField] private float _startx;
    [SerializeField] private float _startY;

    [Header("Move Properties")]
    [SerializeField] private float _speed;
    [SerializeField] private float _directionX;
    [SerializeField] private float _directionY;

    private void FixedUpdate()
    {
        var direction = new Vector2(_directionX, _directionY);
        transform.Translate(direction * _speed * Time.deltaTime);

        if (transform.position.x >= _endX)
        {
            Vector2 pos = new Vector2(_startx, _startY);
            transform.position = pos;
        }
    }
}
