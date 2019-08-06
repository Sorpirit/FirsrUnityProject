
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsController : MonoBehaviour
{
    [SerializeField] private float hp = 100;
    [SerializeField] private float damage = 30;

    public void TakeDamege(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(this.gameObject);
    }

    
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerStatsController player = collision.transform.GetComponent<PlayerStatsController>();
        if (player != null) player.TakeDamage(damage);
    }

}
