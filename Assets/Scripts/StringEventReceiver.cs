using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StringEventReceiver : MonoBehaviour
{
    [SerializeField] StringEventChannelSO stringEventChannelSO;
    [SerializeField] UnityEvent<string> OnReceived = new UnityEvent<string>();
    void OnEnable()
    {
        stringEventChannelSO.OnEventRaised += HandleEventRaised;
    }
    void OnDisable()
    {
        stringEventChannelSO.OnEventRaised -= HandleEventRaised;
    }

    void HandleEventRaised(string val)
    {
        OnReceived?.Invoke(val);
    }
}
