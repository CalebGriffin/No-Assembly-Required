using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelect : MonoBehaviour
{
    int Number;
    string NeededScene;
    public GameObject LoadingScreen;
    
    

    public void Button1Activate()
    {
        Number = 1;
        StartCoroutine("LoadLevel");
    }
    public void Button2Activate()
    {
        Number = 2;
        StartCoroutine("LoadLevel");
    }
    public void Button3Activate()
    {
        Number = 3;
        StartCoroutine("LoadLevel");
    }
    public void Button4Activate()
    {
        Number = 4;
        StartCoroutine("LoadLevel");
    }
    IEnumerator LoadLevel()
    {
        NeededScene = "Level" + Number;
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(NeededScene);
        while (!asyncLoad.isDone)
        {
            yield return null;
            LoadingScreen.SetActive(true);
        }
        if (asyncLoad.isDone)
        {
            LoadingScreen.SetActive(false);
            SceneManager.UnloadSceneAsync("MainMenu");
        }
    }

}
