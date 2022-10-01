using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ColorSelectPanelUI : MonoBehaviour
{
    [SerializeField] UIDocument document;
    void Awake()
    {
        List<RadioButton> colorButtons = document.rootVisualElement.Query<RadioButton>("ColorSelector").ToList();

        foreach(RadioButton button in colorButtons)
        {
            Debug.Log("HELLO");
            button.RegisterCallback<ClickEvent>(ev => Debug.Log("I've been clicked! " + button.style.backgroundColor));
        }
    }
}
