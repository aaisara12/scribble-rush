using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class TimerUI : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] IntEventChannelSO timerUpdateEventChannel;

    Label timerLabel;

    void Awake()
    {
        timerLabel = document.rootVisualElement.Q<Label>("timer-text");
    }

    void OnEnable()
    {
        timerUpdateEventChannel.OnEventRaised += UpdateTimer;
    }

    void OnDisable()
    {
        timerUpdateEventChannel.OnEventRaised -= UpdateTimer;
    }

    void UpdateTimer(int timerVal)
    {
        timerLabel.text = timerVal.ToString();
    }


}
