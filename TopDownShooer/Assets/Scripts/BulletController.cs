using System;
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
    public Transform parent;

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
        if (collision.gameObject.transform == parent) return;

        if (collision.collider.gameObject.layer  == LayerMask.NameToLayer("HitBox")) {
            BodyPart part = BodyPart.BODY;
            if (!Enum.TryParse(collision.collider.name, out part))
            {
                Debug.Log("Body part CONVERT error. Cant convert \"" + collision.collider.name + "\" to body part. \n Pleas add corect it or add it to body part");
            }

            Damage damage = new Damage(this.damage, part);

            HpStats hpStats = collision.transform.gameObject.GetComponentInParent<HpStats>();
            if (hpStats != null)
            {
                hpStats.TakeDamage(damage);
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("Cannt find the HpStats on gameObject");
            }
        }
    }


}
