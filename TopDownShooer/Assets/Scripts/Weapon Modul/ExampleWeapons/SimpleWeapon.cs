﻿using System.Collections;
using UnityEngine;

public class SimpleWeapon : Weapon
{

    public SimpleWeapon()
    {
        weaponModel = new WeaponModel("Simple Weapon", 230, 0.1f, 3f, 230, 0.2f);
    }


    public override void Shoot(RaycastHit2D hitInfo)
    {
        EnemyStatsController enemy = hitInfo.transform.GetComponent<EnemyStatsController>();
        if (enemy != null) enemy.TakeDamege(weaponModel.damage);
    }

    public override void Reload()
    {
        Debug.Log("Reload");
    }

    public override IEnumerator shootVisualEffects(RaycastHit2D hitInfo, Transform firePoint)
    {
        LineRenderer line = firePoint.parent.GetComponentInChildren<LineRenderer>();
        if(line != null)
        {
            line.SetPosition(0, firePoint.position);

            if (hitInfo) {
                line.SetPosition(1, hitInfo.point);
            }
            else
            {
               
                line.SetPosition(1, firePoint.position + firePoint.up * 100);
                
            }

            line.enabled = true;
        }

        yield return new WaitForSeconds(0.02f);

        if(line != null)
        {
            line.enabled = false;
        }
       
    }

    public override IEnumerator reloadVisualEffects(Transform position)
    {
        yield return new WaitForSeconds(0f);
    }
}
