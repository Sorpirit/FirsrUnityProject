using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponManager : MonoBehaviour
{

    public WeaponController controller;

    private int pos = 0;
    private Weapon[] weapons = {new Gun(), new AK47(),new SniperRifle()};

    private void Start()
    {
        controller.setWeapon(weapons[pos]);
    }

    void Update()
    {
        //Right mouse btn
        if(Input.GetMouseButtonDown(1)){
            chengWeapon();
        }
    }

    public void chengWeapon()
    {
        pos++;
        if (pos > weapons.Length - 1) pos = 0;
        controller.setWeapon(weapons[pos]);
    }
}
