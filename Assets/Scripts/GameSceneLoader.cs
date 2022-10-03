using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class GameSceneLoader
{
    static string currentPrimarySceneName = "";

    public static void LoadScene(string sceneName)
    {
        void LoadNextScene()
        {
            SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            currentPrimarySceneName = sceneName;
        }
        if(currentPrimarySceneName == "")
            currentPrimarySceneName = SceneManager.GetActiveScene().name;
        SceneManager.UnloadSceneAsync(currentPrimarySceneName).completed += (p) => LoadNextScene();
    }

}
