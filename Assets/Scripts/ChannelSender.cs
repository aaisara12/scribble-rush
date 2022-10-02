using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChannelSender<T> : MonoBehaviour
{
    [SerializeField] EventChannelSO<T> channel;

    public void SendValue(T val)
    {
        channel.RaiseEvent(val);
    }
}
