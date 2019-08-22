using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private WeaponController weapon;

    void Update()
    {
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (input != Vector2.zero || Input.GetMouseButton(0)) {
    
            weapon.Shoot();
        }
    }
}
