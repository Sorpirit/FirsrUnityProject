using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;

public class En_Shoot : MonoBehaviour
{

    [SerializeField] private GameObject projectTile;
    [SerializeField] private Transform firePoint;
    [SerializeField] private Transform target;
    [SerializeField] private AIPath pathfinding;

    [SerializeField] private float fireRate;

    private float fierRateTimer;

    private void Start()
    {
        fierRateTimer = fireRate;
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
        bullet.GetComponent<BulletController>().target = target;
    }
  
}
