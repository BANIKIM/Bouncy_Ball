using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //매개변수 Default 값
    public static void LoadScene(string scenenam="")
    {
        if(scenenam.Equals(""))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            SceneManager.LoadScene(scenenam);
        }
    }
}
