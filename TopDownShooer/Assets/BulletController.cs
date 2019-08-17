using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    [SerializeField] private float initalSpeed;
    [SerializeField] private float acc;
    [SerializeField] private float maxSpeed;
    [SerializeField] private float lifeTime; // In seconds
    [SerializeField] private float damage;

    public Transform target;

    private float speed;
    private Rigidbody2D myRb;
    
    private void Start()
    {
        myRb = gameObject.GetComponent<Rigidbody2D>();
        speed = initalSpeed;
        Destroy(gameObject,lifeTime);


        myRb.velocity = transform.up * speed;
    }

    private void FixedUpdate()
    {
        if (speed < maxSpeed)
        {
            transform.up = new Vector2(target.position.x - transform.position.x,
               target.position.y - transform.position.y).normalized;

            speed += acc;
            myRb.velocity = transform.up * speed;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        switch (collision.transform.tag)
        {
            case "Player":

                PlayerStatsController playerStats = collision.gameObject.GetComponent<PlayerStatsController>();
                if(playerStats != null)
                {
                    playerStats.TakeDamage(damage);
                    Destroy(gameObject);
                }
                break;
        }
    }


}
