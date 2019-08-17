using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK47 : SimpleWeapon
{
    public AK47()
    {
        weaponModel = new WeaponModel("AK-47", 30, 0.17f, 3.6f, 45, 0.14f);
    }
}
