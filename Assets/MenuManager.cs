using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void goToMainMenu(){
        SceneManager.LoadScene(2);
    }
    public void quit(){
        Application.Quit();
    }
    public void goToCarousel(){
        SceneManager.LoadScene(1);
    }
    public void goToCredits(){
        SceneManager.LoadScene(4);
    }
    public void goToGame(){
        SceneManager.LoadScene(0);
        SceneManager.LoadScene(3,LoadSceneMode.Additive);

    }

    public void openLink(string link){
        Application.OpenURL(link);
    }
}
