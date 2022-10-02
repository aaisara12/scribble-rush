using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoidChannelSender : MonoBehaviour
{
    [SerializeField] VoidEventChannelSO voidEventChannel;
    public void SendValue()
    {
        voidEventChannel.RaiseEvent();
    }

}
