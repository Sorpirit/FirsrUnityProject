using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovemenController : MonoBehaviour
{
    [SerializeField] private FixedJoystick movementJoystick;
    [SerializeField] private FixedJoystick faceingJoyStick;
    [SerializeField] private float acc = 1;
    [SerializeField] private int maxSpeed = 1;

    private Rigidbody2D rb; 
    private Vector2 moveInput;
    private Vector2 faceInput;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        moveInput = new Vector2(movementJoystick.Horizontal, movementJoystick.Vertical);
        faceInput = new Vector2(faceingJoyStick.Horizontal, faceingJoyStick.Vertical);
        
    }

    private void FixedUpdate()
    {
        
        if(faceInput != Vector2.zero)
        {
            transform.up = faceInput.normalized;
        }
        else if(moveInput != Vector2.zero)
        {
            transform.up = moveInput.normalized;
        }

        if (moveInput != Vector2.zero)
        {

            Move();

        }
        else if (rb.velocity != Vector2.zero)
        {
            rb.velocity = Vector2.zero;
        }


    }

    private void Move()
    {
        if (rb.velocity.magnitude < maxSpeed)
        {
            rb.velocity += (Vector2)moveInput.normalized * acc * Time.deltaTime;
        }
    }

}
