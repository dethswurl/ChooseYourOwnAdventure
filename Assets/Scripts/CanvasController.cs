using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour
{
    private Canvas canvas;

    // Start is called before the first frame update
    void Start()
    {
        canvas = GetComponent<Canvas>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Vector2 GetScalesWH()
    {
        float givenW = canvas.pixelRect.width;
        float givenH = canvas.pixelRect.height;
        float scaleW = givenW / 1080;
        float scaleH = givenH / 2160;

        return new Vector2(scaleW, scaleH);
    }
}
