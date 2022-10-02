using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventChannelSO<T> : ScriptableObject
{
    public event System.Action<T> OnEventRaised;
    public void RaiseEvent(T val)
    {
        OnEventRaised?.Invoke(val);
    }
}
