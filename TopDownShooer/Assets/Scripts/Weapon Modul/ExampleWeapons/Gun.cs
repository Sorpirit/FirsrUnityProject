using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : SimpleWeapon
{
    public Gun()
    {
        weaponModel = new WeaponModel("Gun", 20, .34f, 4f, 6, 0.05f);
    }
}
