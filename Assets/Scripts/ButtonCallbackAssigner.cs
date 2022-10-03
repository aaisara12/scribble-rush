using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.Events;

public class ButtonCallbackAssigner : MonoBehaviour
{
    [SerializeField] UIDocument document;
    [SerializeField] UnityEvent OnClick = new UnityEvent();
    [SerializeField] UnityEvent OnHover = new UnityEvent();

    void Awake()
    {
        document.rootVisualElement.Query<Button>().ForEach(b => RegisterCallbacks(b));
    }

    void RegisterCallbacks(Button b)
    {
        b.RegisterCallback<ClickEvent>(ev => OnClick?.Invoke());
        b.RegisterCallback<MouseOverEvent>(ev => OnHover?.Invoke());
    }
}
