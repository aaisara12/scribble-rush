using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorSelectPanelUI : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] List<Color> colorPalette = new List<Color>();
    void Awake()
    {
        List<RadioButton> colorButtons = document.rootVisualElement.Query<RadioButton>("ColorSelector").ToList();

        for(int i = 0; i < colorButtons.Count; i++)
        {
            colorButtons[i].style.backgroundColor = colorPalette[i];
        }
    }
}
