using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float damage = 5;

    [SerializeField] private float sensivity = 0.46f;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private LineRenderer fireLine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (input != Vector2.zero) {

            if (input.magnitude >= sensivity)
                {
                    StartCoroutine(Shoot());
                }
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position,shootingPoint.up);

        if (hitInfo)
        {
            
            fireLine.SetPosition(0, shootingPoint.parent.position);
            fireLine.SetPosition(1, shootingPoint.parent.position + shootingPoint.up * 100);

            fireLine.enabled = true;

            yield return new WaitForSeconds(0.02f);
            
            fireLine.enabled = false;
        }
    }
}
