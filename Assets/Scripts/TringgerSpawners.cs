using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TringgerSpawners : MonoBehaviour
{
    [SerializeField] private Transform _spawner;
    [SerializeField] private int _spawnCount;

    private Transform[] _spawners;
    private SpawnEnemy _currentSpawner;

    private void Start()
    {
        _spawners = new Transform[_spawner.childCount];

        for (int i = 0; i < _spawner.childCount; i++)
        {
            _spawners[i] = _spawner.GetChild(i);
        }

        StartCoroutine(TriggerSpawnres());
    }

    IEnumerator TriggerSpawnres()
    {
        while (_spawnCount > 0)
        {
            for (int i = 0; i < _spawners.Length; i++)
            {
                var waitTime = 2;
                var waitType = new WaitForSeconds(waitTime);
                _spawners[i].TryGetComponent<SpawnEnemy>(out SpawnEnemy spawnEnemy);
                _currentSpawner = spawnEnemy;
                _currentSpawner.Spawn();
                yield return waitType;
            }

            _spawnCount--;
        }
    }
}
