using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VoidChannelReceiver : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO voidEventChannelSO;
    [SerializeField] UnityEvent OnReceived = new UnityEvent();
    
    void OnEnable()
    {
        voidEventChannelSO.OnEventRaised += HandleEventReceived;
    }

    void OnDisable()
    {
        voidEventChannelSO.OnEventRaised -= HandleEventReceived;
    }

    void HandleEventReceived()
    {
        OnReceived?.Invoke();
    }
}
