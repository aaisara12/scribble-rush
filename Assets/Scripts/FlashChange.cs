using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FlashChange : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO finishGameEvent;
    [SerializeField] CanvasGroup whiteScreen;
    [SerializeField] List<GameObject> disappear;
    [SerializeField] List<GameObject> appear;
    [SerializeField] float flashTime = 2;
    [SerializeField] UnityEvent OnChange = new UnityEvent();

    void OnEnable()
    {
        finishGameEvent.OnEventRaised += Flash;
    }

    void OnDisable()
    {
        finishGameEvent.OnEventRaised -= Flash;
    }

    public void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(DoFlash());
    }

    IEnumerator DoFlash()
    {   
        float timeElapsed = 0;
        while(timeElapsed < flashTime)
        {
            whiteScreen.alpha = timeElapsed/flashTime;
            yield return null;
            timeElapsed += Time.deltaTime;
        }
        timeElapsed = 0;
        OnChange?.Invoke();
        foreach(var g in disappear)
        {
            g.SetActive(false);
        }
        foreach(var g in appear)
        {
            g.SetActive(true);
        }
        while(timeElapsed < flashTime)
        {
            whiteScreen.alpha = 1 - (timeElapsed/flashTime);
            yield return null;
            timeElapsed += Time.deltaTime;
        }

    }
}
