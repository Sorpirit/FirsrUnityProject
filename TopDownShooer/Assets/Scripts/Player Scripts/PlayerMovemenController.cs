using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovemenController : MonoBehaviour
{
    [SerializeField] private FixedJoystick movementJoystick;
    [SerializeField] private FixedJoystick faceingJoyStick;

    [SerializeField] private float Speed = 1f;

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
        if (moveInput == Vector2.zero) moveInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).normalized;

        faceInput = new Vector2(faceingJoyStick.Horizontal, faceingJoyStick.Vertical);
        if (faceInput == Vector2.zero  && moveInput == Vector2.zero) faceInput = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        
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
            Stop();
        }


    }

    private void Move()
    {
        rb.velocity = moveInput * Speed; 
    }
    private void Stop()
    {
        rb.velocity = Vector2.zero;
    }

}
