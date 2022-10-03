using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] UnityEvent OnAudioReadied = new UnityEvent();
    
    void Awake()
    {
        SceneManager.LoadSceneAsync("Audio", LoadSceneMode.Additive).completed += PlayMusic;
    }

    void PlayMusic(AsyncOperation obj)
    {
        OnAudioReadied?.Invoke();
    }
}
