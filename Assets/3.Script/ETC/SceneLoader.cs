using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneLoader : MonoBehaviour
{
    //�Ű����� Default ��
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
