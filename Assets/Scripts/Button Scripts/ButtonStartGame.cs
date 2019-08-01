using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;


public class ButtonStartGame : MonoBehaviour, IPointerDownHandler, IPointerClickHandler,
    IPointerUpHandler, IPointerExitHandler, IPointerEnterHandler,
    IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public TextMeshProUGUI startText;
    Color originalTextColor;
    Color modTextColor;


    bool canStart;

    public void Start()
    {
        originalTextColor = startText.color;
        modTextColor = new Color(originalTextColor.r, originalTextColor.g, originalTextColor.g, 0.4f);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Begin");
    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("Dragging");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("Drag Ended");
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("Clicked: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        startText.color = modTextColor;
        Debug.Log("Mouse Down: " + eventData.pointerCurrentRaycast.gameObject.name);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        canStart = true;
        Debug.Log("Mouse Enter");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        startText.color = originalTextColor;
        canStart = false;
        Debug.Log("Mouse Exit");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        startText.color = originalTextColor;
        if (!canStart) return;

        CameraController cameraController = GameObject.Find("Main Camera").GetComponent<CameraController>();
        cameraController.StartGame();
    }

}
