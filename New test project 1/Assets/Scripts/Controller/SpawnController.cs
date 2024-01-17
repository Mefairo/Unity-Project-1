using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpawnController : MonoBehaviour
{
    [SerializeField] protected MeteorSpawner[] _spawners;
    [SerializeField] protected int _countSpawnEnemies;
    [SerializeField] protected float _spawnTime;
    [SerializeField] protected GameObject _prefab;
    [SerializeField] protected Transform _container;
    [SerializeField] protected RoundTime _roundTime;

    protected void Start()
    {
        StartCoroutine(StartSpawnMeteors());
    }

    private void OnEnable()
    {
        _roundTime.NextRoundToStart += NextRoundStart;
    }

    private void OnDisable()
    {
        _roundTime.NextRoundToStart += NextRoundStart;
    }

    protected Vector2 GetRandomSpawnPosition(MeteorSpawner randomSpawner)
    {
        var spawnArea = randomSpawner.transform;

        float x = UnityEngine.Random.Range(spawnArea.position.x - spawnArea.localScale.x / 2f, spawnArea.position.x + spawnArea.localScale.x / 2f);
        float y = UnityEngine.Random.Range(spawnArea.position.y - spawnArea.localScale.y / 2f, spawnArea.position.y + spawnArea.localScale.y / 2f);

        return new Vector2(x, y);

    }

    protected MeteorSpawner PlaceOfSpawn()
    {
        var randomSpawner = _spawners[UnityEngine.Random.Range(0, _spawners.Length)];

        return randomSpawner;
    }

    protected virtual IEnumerator StartSpawnMeteors()
    {
        while (true)
        {
            for (int i = 0; i < _countSpawnEnemies; i++)
            {
                MeteorSpawner spawner = PlaceOfSpawn();
                Vector2 spawnPosition = GetRandomSpawnPosition(spawner);

                GameObject newMeteor = Instantiate(_prefab, spawnPosition, Quaternion.identity, _container);
            }

            yield return new WaitForSeconds(_spawnTime);
        }
    }

    protected void NextRoundStart()
    {
        if (_roundTime.CountRound % 2 == 0)
            _countSpawnEnemies++;

        else
            _spawnTime -= 0.2f;
    }
}
