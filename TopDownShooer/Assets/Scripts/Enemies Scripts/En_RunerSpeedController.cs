using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class En_RunerSpeedController : MonoBehaviour
{
    [SerializeField] private float speedIncreesingValue;
    [SerializeField] private AIPath maxSpeed;
    [SerializeField] private HpStats statsController;

    private float prevHp;

    private void Start()
    {
        prevHp = statsController.hp;
    }

    private void Update()
    {
        if (statsController.hp < prevHp)
        {
            maxSpeed.maxSpeed += speedIncreesingValue / statsController.hp;
            prevHp = statsController.hp;
        }
    }
}
