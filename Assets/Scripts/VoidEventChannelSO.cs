using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Event Channels/Void Event Channel")]
public class VoidEventChannelSO : ScriptableObject
{
    public System.Action OnEventRaised;
    public void RaiseEvent()
    {
        OnEventRaised?.Invoke();
    }
}
