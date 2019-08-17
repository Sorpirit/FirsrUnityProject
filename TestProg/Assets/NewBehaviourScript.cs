using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{

    void Start()
    {
        Debug.Log("All coins: " + PlayerPrefs.GetInt(Consts.COINS));
    }

 
}
