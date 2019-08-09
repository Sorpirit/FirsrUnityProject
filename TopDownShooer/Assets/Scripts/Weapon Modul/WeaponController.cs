using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    //You should set by mamager or monualy
    private Weapon weapon;

   

    
    private int bullets;
    private float reloadTimer;
    private float fireRateTimer;

    //Set by unity
    [SerializeField] private Transform firePoint;

    void Start()
    {
        weapon = new SimpleWeapon();
        bullets = weapon.weaponModel.clip;
        reloadTimer = -1f;
        fireRateTimer = 0f;
    }

    void Update()
    {
        if (fireRateTimer < weapon.weaponModel.fireRate) fireRateTimer += Time.deltaTime;

        if (reloadTimer > weapon.weaponModel.reloadTime) Reload();
        else if(reloadTimer >= 0) reloadTimer += Time.deltaTime;

    }

    public void Shoot()
    {
        if (fireRateTimer >= weapon.weaponModel.fireRate && bullets > 0)
        {
            shoot();

        }else if (bullets <= 0)
        {
            Reload();
        }
    }

    private void shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up);
        if (hitInfo)
        {
            weapon.Shoot(hitInfo);
        }

        bullets--;
        fireRateTimer = 0f;

        StartCoroutine(weapon.shootVisualEffects(hitInfo,firePoint));
    }

    public void Reload()
    {
        if (reloadTimer < 0)
        {

            reloadTimer = 0f;

        }else if (reloadTimer >= weapon.weaponModel.reloadTime)
        {

            weapon.Reload();
            bullets = weapon.weaponModel.clip;
            reloadTimer = -1f;
            StartCoroutine(weapon.reloadVisualEffects(transform));

        }
    }

}
