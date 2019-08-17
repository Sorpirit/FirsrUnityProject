using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScoresSets : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown("p"))
        {
            PlayerPrefs.SetInt(Consts.COINS, PlayerPrefs.GetInt(Consts.COINS) + 1);
            
        }

        if (Input.GetKeyDown("l"))
        {
            SceneManager.LoadScene(sceneBuildIndex: 1);
        }
    }
}
