using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class En_FatController : MonoBehaviour
{
    public int barowRange;

    public void Awake()
    {

    }

    private Transform findClosestBarow()
    {
        KdTree<BarowScript> barows = new KdTree<BarowScript>();
        barows.AddAll(Transform.FindObjectsOfType<BarowScript>().ToList());
        BarowScript barowScript = barows.FindClosest(transform.position);
        //if (barowRange >= barowScript.transform.position)
        {
           
        }

        return null;
    }
}
