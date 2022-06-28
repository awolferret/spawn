using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _spawnCount;
    [SerializeField] private Transform _spawnPoint;

    private Transform[] _spawnPoints;
    private Coroutine _coroutine;

    private void Start()
    {
        _spawnPoints = new Transform[_spawnPoint.childCount];

        for (int i = 0; i < _spawnPoint.childCount; i++)
        {
            _spawnPoints[i] = _spawnPoint.GetChild(i);
        }

        _coroutine = StartCoroutine(SpawnEnemies());
    }

    private IEnumerator SpawnEnemies()
    {
        while (_spawnCount > 0)
        {
            for (int i = 0; i < _spawnPoints.Length; i++)
            {
                int waitTime = 2;
                var waitType = new WaitForSeconds(waitTime);
                Spawn(ChoosePoint(_spawnPoints[i]));
                yield return waitType;
            }

            _spawnCount--;
        }
    }

    private Vector2 ChoosePoint(Transform _spawnPoint)
    {
        float range = 1f;
        float randomX = Random.Range(_spawnPoint.position.x - range, _spawnPoint.position.x + range);
        float randomY = Random.Range(_spawnPoint.position.y - range, _spawnPoint.position.y + range);
        Vector2 whereToSpawn = new Vector2(randomX, randomY);
        return whereToSpawn;
    }

    private void Spawn(Vector2 whereToSpawn)
    {
        Enemy newObject = Instantiate(_enemy,whereToSpawn, Quaternion.identity);
    }  
}
