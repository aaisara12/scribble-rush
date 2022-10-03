using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIActivator : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO resetUIChannel;
    [SerializeField] VoidEventChannelSO clearUIChannel;
    
    void OnEnable()
    {
        resetUIChannel.RaiseEvent();
        Debug.Log("RESET UI");
    }

    void OnDisable()
    {
        clearUIChannel.RaiseEvent();
        Debug.Log("CLEAR UI");
    }
}
