using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ScreenLoader : MonoBehaviour
{
    public string sceneName;

    public void LoadScene()
    {
        SceneManager.LoadScene(sceneName);
    }
    public void Exit()
    {
        Debug.Log("enter quit 1");
        Application.Quit();

        Debug.Log("enter quit 2");
        throw new System.Exception("dsd");

    }
}
