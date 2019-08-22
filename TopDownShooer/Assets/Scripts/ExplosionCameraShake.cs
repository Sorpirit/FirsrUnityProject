using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class ExplosionCameraShake : MonoBehaviour
{
    public float timeDuration;

    private void Start()
    {
        gameObject.GetComponent<CinemachineImpulseSource>().GenerateImpulse(new Vector3(1, 1));
    }

    private void Update()
    {
        timeDuration -= Time.deltaTime;

        if (timeDuration <= 0) Destroy(gameObject);
    }
}
