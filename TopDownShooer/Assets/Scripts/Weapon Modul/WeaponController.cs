using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{

    //You should set by mamager or monualy
    private Weapon weapon;
    

    [SerializeField] private int bullets;
    private int clip;
    private float reloadTimer;
    private float fireRateTimer;

    //Set by unity
    [SerializeField] private Transform firePoint;

    void Update()
    {
        if (fireRateTimer < weapon.weaponModel.fireRate) fireRateTimer += Time.deltaTime;

        if (reloadTimer > weapon.weaponModel.reloadTime) Reload();
        else if(reloadTimer >= 0) reloadTimer += Time.deltaTime;

    }

    public void Shoot()
    {
        if (fireRateTimer >= weapon.weaponModel.fireRate && clip > 0)
        {
            shoot();

        }else if (clip <= 0)
        {
            Reload();
        }
    }

    private void shoot()
    {
        float xDispersion = Random.Range(-weapon.weaponModel.dispersion, weapon.weaponModel.dispersion);
        float yDispersion = Random.Range(-weapon.weaponModel.dispersion, weapon.weaponModel.dispersion);

        firePoint.up = new Vector2(firePoint.up.x + xDispersion, firePoint.up.y + yDispersion).normalized;

        RaycastHit2D hitInfo = Physics2D.Raycast(firePoint.position, firePoint.up, Mathf.Infinity, LayerMask.GetMask("HitBox"));
        if (hitInfo)
        {
            weapon.Shoot(hitInfo);
            
        }


        clip--;
        fireRateTimer = 0f;

        StartCoroutine(weapon.shootVisualEffects(hitInfo,firePoint));

        firePoint.up = transform.up;
    }

    public void Reload()
    {
        if (reloadTimer < 0)
        {

            reloadTimer = 0f;

        }else if (reloadTimer >= weapon.weaponModel.reloadTime)
        {

            weapon.Reload();
            
            clip = weapon.weaponModel.clip;
            if(clip > bullets)
            {
                clip = bullets;
                bullets = 0;
                Debug.Log("Out of amo");
            }
            else
            {
                bullets -= clip;
            }

            reloadTimer = -1f;
            StartCoroutine(weapon.reloadVisualEffects(transform));

        }
    }
    public void setWeapon(Weapon weapon)
    {
        //@TODO
        this.weapon = weapon;
        clip = weapon.weaponModel.clip; // Logical Error
        reloadTimer = -1f;
        fireRateTimer = 0f;
    }

    public Weapon GetWeapon()
    {
        return weapon;
    }
}
