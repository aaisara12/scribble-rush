using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ColorSelectPanelUI : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] List<Color> colorPalette = new List<Color>();
    [SerializeField] UnityEvent<Color> OnColorSelected = new UnityEvent<Color>();
    void Awake()
    {
        List<RadioButton> colorButtons = document.rootVisualElement.Query<RadioButton>("ColorSelector").ToList();

        for(int i = 0; i < colorButtons.Count; i++)
        {
            colorButtons[i].style.backgroundColor = colorPalette[i];
            Color thisColor = colorPalette[i];
            colorButtons[i].RegisterCallback<ClickEvent>(ev => OnColorSelected?.Invoke(thisColor));
        }
    }

    
}
