using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStatsController : MonoBehaviour
{

    [SerializeField] private float hp = 100;

    public void TakeDamage(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(this.gameObject);
    }
}
