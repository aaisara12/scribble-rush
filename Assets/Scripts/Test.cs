using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] StringChannelSender channelSender;
    [SerializeField] string prompt;
    void Start()
    {
        //GetComponent<StringChannelSender>().SendValue("Hello World!");

        channelSender.SendValue(prompt);
    }

}
