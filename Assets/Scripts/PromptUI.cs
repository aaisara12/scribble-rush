using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PromptUI : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] StringEventChannelSO promptUpdateEventChannel;
    [SerializeField] AudioCue promptUpdateAudioCue;

    Label promptLabel;

    void Awake()
    {
        promptLabel = document.rootVisualElement.Q<Label>("prompt");
    }

    void OnEnable()
    {
        promptUpdateEventChannel.OnEventRaised += UpdatePrompt;
    }

    void OnDisable()
    {
        promptUpdateEventChannel.OnEventRaised -= UpdatePrompt;
    }

    void UpdatePrompt(string newPrompt)
    {
        promptLabel.text = newPrompt;
        promptUpdateAudioCue?.PlayAudioCue();
    }


}
