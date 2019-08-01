using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightMovementScript : MonoBehaviour
{
    [SerializeField]
    Light light;

    [SerializeField]
    float dimSpeed;

    float startIntensity;
    float startWidth;
    bool down;

    // Start is called before the first frame update
    void Start()
    {
        startIntensity = light.intensity;
    }

    // Update is called once per frame
    void Update()
    {
        if (!down)
        {
            if (light.intensity < 0.4f)
                light.intensity += dimSpeed;
            else
                down = true;
        }
        else
        {
            if (light.intensity > 0.2f)
                light.intensity -= dimSpeed;
            else
                down = false;
        }
       
    }
}
