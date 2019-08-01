using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


[ExecuteInEditMode]
public class ButtonNormal : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Material stateNormal;
    public Material statePressed;

    public bool pressed;

    CanvasRenderer myRenderer;

    // Start is called before the first frame update
    void Start()
    {
        myRenderer = GetComponent<CanvasRenderer>();

        if(stateNormal != null)
            transform.GetComponent<Image>().material = stateNormal;

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        pressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        pressed = false;
    }

    public void Update()
    {
        if(myRenderer == null)
            myRenderer = GetComponent<CanvasRenderer>();

        if (pressed)
            transform.GetComponent<Image>().material = statePressed;
        else
            transform.GetComponent<Image>().material = stateNormal;
    }
}
