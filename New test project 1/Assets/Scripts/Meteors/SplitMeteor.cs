using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplitMeteor : MonoBehaviour
{
    [SerializeField] private Meteor _smallMeteor;
    [SerializeField] private int _meteorCountSplit;

    private MeteorHealth _meteorHealth;
    private Meteor _meteorThis;

    private void Awake()
    {
        _meteorThis = GetComponent<Meteor>();
        _meteorHealth = GetComponent<MeteorHealth>();
    }

    private void OnEnable()
    {
        _meteorThis.OnMeteorDestroy += SplitBigMeteor;
        _meteorHealth.MeteorDestroyed += SplitBigMeteor;
    }

    private void OnDisable()
    {
        _meteorThis.OnMeteorDestroy -= SplitBigMeteor;
        _meteorHealth.MeteorDestroyed -= SplitBigMeteor;
    }

    private void SplitBigMeteor()
    {      
        for (int i = 0; i < _meteorCountSplit; i++)
        {
            Instantiate(_smallMeteor, transform.position, Quaternion.identity);
        }
    }
}
