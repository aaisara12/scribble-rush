using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIVisibilityToggler : MonoBehaviour
{
    [SerializeField] UIDocument document;

    void Awake()
    {
        SetVisibility(false);   // Default not showing
    }

    public void SetVisibility(bool isVisible)
    {
        document.rootVisualElement.style.visibility = isVisible? Visibility.Visible : Visibility.Hidden;
    }
}
