using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallMeteor : MonoBehaviour
{
    private MoveMeteor _moveMeteor;

    private void Start()
    {
        _moveMeteor = GetComponent<MoveMeteor>();

        _moveMeteor.MoveAfterSplit();
    }
}
