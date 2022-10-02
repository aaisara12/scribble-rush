using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] UnityEngine.UI.Image image;
    void Start()
    {
        //GetComponent<StringChannelSender>().SendValue("Hello World!");

        GetComponent<VoidChannelSender>().SendValue();
    }

    public void SetColor(Color color)
    {
        image.color = color;
    }

}
