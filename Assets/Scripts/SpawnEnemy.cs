using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Transform _spawnPoint;

    public void Spawn()
    {
        float randomX = Random.Range(_spawnPoint.position.x - 1f, _spawnPoint.position.x + 1f);
        float randomY = Random.Range(_spawnPoint.position.y - 1f, _spawnPoint.position.y + 1f);
        Vector2 whereToSpawn = new Vector2(randomX, randomY);
        GameObject newObject = Instantiate(_enemy,whereToSpawn, Quaternion.identity);
    }  
}