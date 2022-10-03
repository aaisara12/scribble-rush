using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class FinishPanelUI : MonoBehaviour
{
    [SerializeField] UIDocument document;

    void Awake()
    {
        document.rootVisualElement.Q<Button>("draw-again").RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("Main"));
        document.rootVisualElement.Q<Button>("gallery").RegisterCallback<ClickEvent>(ev => SceneManager.LoadScene("Carousel"));
    }
}
