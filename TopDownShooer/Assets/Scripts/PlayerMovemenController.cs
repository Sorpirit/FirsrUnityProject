using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovemenController : MonoBehaviour
{
    [SerializeField]
    private FixedJoystick joystick;
    [SerializeField]
    private float speed;

    private void FixedUpdate()
    {
        transform.Translate(new Vector3(joystick.Horizontal, joystick.Vertical) * speed * Time.deltaTime);
    }

}
