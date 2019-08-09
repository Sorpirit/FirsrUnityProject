using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShootingController : MonoBehaviour
{

    [SerializeField] private Transform shootingPoint;
    [SerializeField] private float damage = 5;
    private float relload = 0f;
    [SerializeField] private float relloadTime = 1f;

    [SerializeField] private float sensivity = 0.46f;
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private LineRenderer fireLine;

    [SerializeField] private WeaponController weapon;

    // Start is called before the first frame update
    void Start()
    {
        relload = relloadTime;

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 input = new Vector2(joystick.Horizontal, joystick.Vertical);
        if (input != Vector2.zero || Input.GetKey(KeyCode.Space)) {
    
            weapon.Shoot();
        }
    }

    IEnumerator Shoot()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(shootingPoint.position,shootingPoint.up);

        if (hitInfo)
        {
            Debug.Log("Shoot: " + hitInfo.transform.name);
            EnemyStatsController controller = hitInfo.transform.GetComponent<EnemyStatsController>();
            if(controller != null)
            {
                controller.TakeDamege(damage);

                fireLine.SetPosition(0, shootingPoint.parent.position);
                fireLine.SetPosition(1, hitInfo.point);
                Debug.Log("Hit somthing");
            }
            else
            {
                Debug.Log("Hit somthing else");
                Debug.Log("Pos:" + hitInfo.point.ToString());
               
                fireLine.SetPosition(0, shootingPoint.position);
                fireLine.SetPosition(1, hitInfo.point);
            }

        }
        else
        {
            fireLine.SetPosition(0, shootingPoint.position);
            fireLine.SetPosition(1, shootingPoint.position + shootingPoint.up * 100);
        }

        fireLine.enabled = true;

        yield return new WaitForSeconds(0.02f);

        

        fireLine.enabled = false;
    }
}
