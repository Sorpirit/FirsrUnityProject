using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class En_RunerSpeedController : MonoBehaviour
{
    [SerializeField] private float speedIncreesingValue;
    [SerializeField] private AIPath maxSpeed;
    [SerializeField] private EnemyStatsController statsController;

    private float prevHp;

    private void Start()
    {
        prevHp = statsController.getHp();
    }

    private void Update()
    {
        if (statsController.getHp() < prevHp)
        {
            maxSpeed.maxSpeed += speedIncreesingValue / statsController.getHp();
            prevHp = statsController.getHp();
        }
    }
}
