using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameInitializer : MonoBehaviour
{
    static bool isGameInitialized = false;
    [SerializeField] UnityEvent OnAudioReadied = new UnityEvent();
    
    void Awake()
    {
        if(isGameInitialized) return;

        SceneManager.LoadSceneAsync("Audio", LoadSceneMode.Additive).completed += PlayMusic;
        SceneManager.LoadSceneAsync("UI", LoadSceneMode.Additive);
        isGameInitialized = true;
    }

    void PlayMusic(AsyncOperation obj)
    {
        OnAudioReadied?.Invoke();
    }
}
