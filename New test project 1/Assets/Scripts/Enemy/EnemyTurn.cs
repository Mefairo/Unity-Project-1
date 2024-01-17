using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class EnemyTurn : MonoBehaviour
{
    [SerializeField] private float _offset;

    private EnemyMovement _enemyMovement;

    private void Awake()
    {
        _enemyMovement = GetComponentInParent<EnemyMovement>();
    }

    private void FixedUpdate()
    {
        var difference = _enemyMovement.Player.transform.position - transform.position;
        var rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + _offset);
    }
}
