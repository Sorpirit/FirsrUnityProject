using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class En_Shoot : MonoBehaviour
{

    [SerializeField] private GameObject projectTile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private AIPath pathfinding;

    [SerializeField] private float fireRate;

    private Transform target;
    private float fierRateTimer;

    private void Start()
    {
        fierRateTimer = fireRate;
        target = gameObject.GetComponent<AIDestinationSetter>().target;
    }

    private void Update()
    {
        if (pathfinding.reachedDestination)
        {
            if (fierRateTimer >= fireRate)
            {
                Shoot();
                fierRateTimer = 0f;               
            }
            else
            {
                fierRateTimer += Time.deltaTime;
            }

            transform.up = new Vector2(target.position.x - transform.position.x, 
                target.position.y - transform.position.y).normalized;
        }

        

        
    }

    public void Shoot()
    {
        GameObject bullet = Instantiate(projectTile,firePoint.position,firePoint.rotation);
        BulletController bulletController = bullet.GetComponent<BulletController>();
        bulletController.target = target;
        bulletController.parent = gameObject.transform;
        
    }
  
}
