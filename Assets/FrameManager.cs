using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class FrameManager : MonoBehaviour
{

    public TextMeshProUGUI label;
    public Image drawing;

    public void setDrawing(Sprite sprite, string prompt)
    {
        drawing.sprite = sprite;
        label.text = prompt;
    }

}
