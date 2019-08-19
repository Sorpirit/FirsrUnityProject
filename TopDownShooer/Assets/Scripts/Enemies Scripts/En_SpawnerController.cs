﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class En_SpawnerController : MonoBehaviour
{

    [SerializeField] private GameObject enemy;
    [SerializeField] private float spawnRate;
    [SerializeField] private int enemysAmount;
    [SerializeField] private float fireRate;
    [SerializeField] private float damage;
    [SerializeField] private EnemyStatsController myStats;
    [SerializeField] private AIPath path;

    private Transform target;
    private PlayerStatsController victim;

    private float fireRateTimer;
    private float spawnRateTimer;

    void Start()
    {
        target = gameObject.GetComponent<AIDestinationSetter>().target;
        victim = target.gameObject.GetComponent<PlayerStatsController>();
        enemy.gameObject.GetComponent<AIDestinationSetter>().target = target;

        fireRateTimer = fireRate;
        spawnRateTimer = 0f; 
    }

    void Update()
    {
        if (path.reachedDestination && fireRateTimer >= fireRate)
        {
            victim.TakeDamage(damage);
            myStats.Heal(damage);
            fireRateTimer = 0f;

        }else if (fireRateTimer < fireRate)
        {
            fireRateTimer += Time.deltaTime;
        }

        if (spawnRateTimer >= spawnRate)
        {
            spawnEnemys();
            spawnRateTimer = 0f;
        }
        else
        {
            spawnRateTimer += Time.deltaTime;
        }
    }

    private void spawnEnemys()
    {
        for (int i=0; i < enemysAmount; i++)
        {
            Instantiate(enemy, transform.position, Quaternion.identity);
        }
    }
}
