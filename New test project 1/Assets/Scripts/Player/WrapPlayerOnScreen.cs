using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WrapPlayerOnScreen : MonoBehaviour
{
    private Camera _camera;
    private float _screenWidth;
    private float _screenHeight;

    private void Start()
    {
        _camera = Camera.main;

        if (_camera == null)
            Debug.Log("camera is null");

        else
        {
            _screenWidth = _camera.orthographicSize * 2 * Screen.width / Screen.height;
            _screenHeight = _camera.orthographicSize * 2;
        }

    }

    private void Update()
    {
        WrapAroundScreen();
    }

    private void WrapAroundScreen()
    {
        Vector3 newPosition = transform.position;

        if (transform.position.x < -_screenWidth / 2)
            newPosition.x = _screenWidth / 2;

        else if (transform.position.x > _screenWidth / 2)
            newPosition.x = -_screenWidth / 2;

        if (transform.position.y < -_screenHeight / 2)
            newPosition.y = _screenHeight / 2;

        else if (transform.position.y > _screenHeight / 2)
            newPosition.y = -_screenHeight / 2;

        transform.position = newPosition;   
    }
}
