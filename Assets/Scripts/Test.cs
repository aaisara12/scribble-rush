using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //GetComponent<StringChannelSender>().SendValue("Hello World!");

        GetComponent<IntChannelSender>().SendValue(3);
    }

}
