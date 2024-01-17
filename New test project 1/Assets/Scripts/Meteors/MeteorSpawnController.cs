using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Pool;

public class MeteorSpawnController : SpawnController
{

    protected override IEnumerator StartSpawnMeteors()
    {
        while (true)
        {
            for (int i = 0; i < _countSpawnEnemies; i++)
            {
                MeteorSpawner spawner = PlaceOfSpawn();
                Vector2 spawnPosition = GetRandomSpawnPosition(spawner);


                GameObject newMeteorObj = Instantiate(_prefab, spawnPosition, Quaternion.identity, _container);
                var newMeteor = newMeteorObj.GetComponent<Meteor>();

                DirectionMove(newMeteor, spawner);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    private void DirectionMove(Meteor meteor, MeteorSpawner spawner)
    {
        Vector3 directionMove = new Vector3();

        switch (spawner.typeSpawn)
        {
            case TypeMeteorSpawner.Top:
                directionMove = Vector3.down;
                break;

            case TypeMeteorSpawner.Bottom:
                directionMove = Vector3.up;
                break;

            case TypeMeteorSpawner.Right:
                directionMove = Vector3.left;
                break;

            case TypeMeteorSpawner.Left:
                directionMove = Vector3.right;
                break;
        }

        meteor._moveMeteor.MoveDirection(directionMove);
    }
}
