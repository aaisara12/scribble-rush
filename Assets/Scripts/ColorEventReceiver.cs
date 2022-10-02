using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ColorEventReceiver : MonoBehaviour
{
    [SerializeField] ColorEventChannelSO colorSelectedEventChannel;
    [SerializeField] UnityEvent<Color> OnColorSelected = new UnityEvent<Color>();
    
    void OnEnable()
    {
        colorSelectedEventChannel.OnEventRaised += HandleColorSelected;
    }

    void Disable()
    {
        colorSelectedEventChannel.OnEventRaised -= HandleColorSelected;
    }

    void HandleColorSelected(Color color)
    {
        OnColorSelected?.Invoke(color);
    }
}
