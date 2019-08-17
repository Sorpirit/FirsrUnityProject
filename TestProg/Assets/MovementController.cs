using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{

    Rigidbody rigidbody;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity += new Vector3(0.1f,0);
        } else if (Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity += new Vector3(-0.1f, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity += new Vector3(0, 0, 0.1f);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity += new Vector3(0, 0, -0.1f);
        }
    }
}