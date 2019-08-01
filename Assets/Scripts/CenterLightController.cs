using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CenterLightController : MonoBehaviour
{
    public Canvas canvas;
    private Light sceneLight;


    // Start is called before the first frame update
    void Start()
    {
        sceneLight = GetComponent<Light>();

        Vector2 scales = canvas.GetComponent<CanvasController>().GetScalesWH();

        float scaleW = scales.x;
        float scaleH = scales.y;

        //sceneLight.range *= Mathf.Max(scaleW, scaleH);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
