using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private float spawnRate;
    [SerializeField] private GameObject enemy;
    [SerializeField] private Transform target;

    [SerializeField] private Transform[] spawnerPoints;

    private float spawnTimer = 0f;

    private void Start()
    {
        enemy.GetComponent<AIDestinationSetter>().target = target;
    }

    private void Update()
    {
        spawnTimer += Time.deltaTime;

        if (spawnTimer >= spawnRate)
        {
            spawnTimer = 0f;
            SpawnNewEnemy();
        }
    }

    private void SpawnNewEnemy()
    {
        int randomIndex = Random.Range(0,spawnerPoints.Length);
        GameObject obj = Instantiate(enemy,spawnerPoints[randomIndex].position, Quaternion.identity);
        obj.transform.SetParent(transform);
    }
}
