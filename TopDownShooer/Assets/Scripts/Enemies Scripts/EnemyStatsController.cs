
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatsController : MonoBehaviour
{
    [SerializeField] private float maxHp = 100;
    [SerializeField] private float damage = 30;

    private float hp;

    private void Start()
    {
        hp = maxHp;
    }

    public void TakeDamege(float damage)
    {
        hp -= damage;
        if (hp <= 0) Destroy(this.gameObject);
    }
    public void Heal(float heal)
    {
        hp += heal;
        if (hp > maxHp) hp = maxHp;
    }

    public float getHp()
    {
        return hp;
    }
    

    private void OnCollisionStay2D(Collision2D collision)
    {
        PlayerStatsController player = collision.transform.GetComponent<PlayerStatsController>();
        if (player != null) player.TakeDamage(damage);
    }

}
