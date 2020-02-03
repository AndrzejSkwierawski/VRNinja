using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public string livesLevel, timesLevel, mixedLevel, results, menu;

   public void OnMouseDown()
    {
        if(gameObject.name == "LivesCube")
        {
            Application.LoadLevel(livesLevel);
        }
        else if (gameObject.name == "TimeCube")
        {
            Application.LoadLevel(timesLevel);
        }
        else if (gameObject.name == "TimeLivesCube")
        {
            Application.LoadLevel(mixedLevel);
        }
        else if (gameObject.name == "ResultsCube")
        {
            Application.LoadLevel(results);
        }
        else if (gameObject.name == "ReturnCube")
        {
            Application.LoadLevel(menu);
        }


    }
}
