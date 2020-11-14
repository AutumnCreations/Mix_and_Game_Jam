using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Enemy[] enemyTypes;
    [SerializeField] float spawnTimeMin = .5f;
    [SerializeField] float spawnTimeMax = 10f;

    private float currentTime = 0;
    private float spawnTime;

    void Start()
    {
        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime > spawnTime)
        {
            SpawnEnemy();
            currentTime = 0;
        }
    }

    private void SpawnEnemy()
    {
        int enemyToSpawn = Random.Range(0, enemyTypes.Length);
        Instantiate(enemyTypes[enemyToSpawn], transform.position, Quaternion.identity);

        spawnTime = Random.Range(spawnTimeMin, spawnTimeMax);
    }
}
