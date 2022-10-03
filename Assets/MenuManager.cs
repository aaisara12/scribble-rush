using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public void goToMainMenu(){
        SceneManager.LoadScene("MainMenu");
    }
    public void quit(){
        Application.Quit();
    }

    public void goToCarousel(){
        SceneManager.LoadScene("Carousel");
    }

    public void goToCredits(){
        SceneManager.LoadScene("Credits");
    }

    public void goToGame(){
        SceneManager.LoadScene("Main");
        SceneManager.LoadScene("UI",LoadSceneMode.Additive);
    }

    public void openLink(string link){
        Application.OpenURL(link);
    }
}
