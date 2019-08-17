using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperRifle : SimpleWeapon
{
    public SniperRifle()
    {
        weaponModel = new WeaponModel("Sniper Rifle", 230, 1f, 5f, 5, 0f);
    }
}
