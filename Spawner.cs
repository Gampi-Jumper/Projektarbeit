using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float startSpawnTime;
    public float minSpawnTime;
    public float spawnAcceleration;
    private float nextSpawnTime;

    public GameObject enemy;
    public Transform[] spawnPoints;

    void Update()
    {
        if (Time.time > nextSpawnTime)
        {
            Transform randomSpawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemy, randomSpawnPoint.position, Quaternion.identity);

            startSpawnTime *= spawnAcceleration;
            startSpawnTime = Mathf.Max(startSpawnTime, minSpawnTime);
            nextSpawnTime = Time.time + startSpawnTime;
        }
    }
}
