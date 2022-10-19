using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MinorAutoScroll : MonoBehaviour
{
    public ScrollRect scroll;
    private bool autoScroll=true;


    // Start is called before the first frame update
    void Start()
    {
        scroll.verticalNormalizedPosition = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
            autoScroll=false;

        if(autoScroll)
            scroll.velocity = new Vector2(0,60);

    }

}
