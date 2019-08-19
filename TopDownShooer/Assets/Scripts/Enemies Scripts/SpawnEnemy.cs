using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class SpawnEnemy : MonoBehaviour
{

    [SerializeField] private float spawnRate;
    [SerializeField] private Transform target;

    [SerializeField] private GameObject[] enemy;

    [SerializeField] private Transform[] spawnerPoints;

    private float spawnTimer = 0f;

    private void Start()
    {

        SetEnemysTarget();
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
        GameObject obj = Instantiate(enemy[Random.Range(0,enemy.Length)],spawnerPoints[randomIndex].position, Quaternion.identity);
        obj.transform.SetParent(transform);
    }

    private void SetEnemysTarget()
    {
        for (int i=0;i<enemy.Length;i++)
        {
            enemy[i].GetComponent<AIDestinationSetter>().target = target;
        }
    }
}
