using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void goToMainMenu(){
        GameSceneLoader.LoadScene("MainMenu");
    }
    public void quit(){
        Application.Quit();
    }

    public void goToCarousel(){
        GameSceneLoader.LoadScene("ScrollGallery");
    }

    public void goToCredits(){
        GameSceneLoader.LoadScene("Credits");
    }

    public void goToGame(){
        GameSceneLoader.LoadScene("Instructions");
    }


    public void openLink(string link){
        Application.OpenURL(link);
    }
}
