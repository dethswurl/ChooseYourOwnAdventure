using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class RightLightMove : MonoBehaviour
{
    public Canvas canvas;
    private Light sceneLight;

    public float topOffset = 0f;
    public float peakTopOffset, lowTopOffset;

    public float progressed;

    public float peakUp, peakDown;
    private float startX, endX;

    public float peakSpotAngle, lowSpotAngle;
    private float startSpotAngle, endSpotAngle;

    public float smoothing = 1f;

    public int defaultPauseBetweenMovements = 2;
    public int randomBetweenMovements = 1;

    bool switched;

    // Start is called before the first frame update
    void Start()
    {
        sceneLight = GetComponent<Light>();

        setOffset(((GameObject)GameObject.FindWithTag("Scroll View")).GetComponent<ScrollRect>().normalizedPosition);

        if (System.Math.Abs(peakSpotAngle) < 0.1f)
            peakSpotAngle = sceneLight.spotAngle;

        if (System.Math.Abs(lowSpotAngle) < 0.1f)
            lowSpotAngle = sceneLight.spotAngle;

        startX = transform.rotation.x;
        endX = -peakUp;

        startSpotAngle = sceneLight.spotAngle;
        endSpotAngle = peakSpotAngle;

        StartCoroutine(MoveTo());
    }

    //My favs
    // width = 1080
    // height = 2160
    void FindScale()
    {
        Vector2 scales = canvas.GetComponent<CanvasController>().GetScalesWH();

        float scaleW = scales.x;
        float scaleH = scales.y;

        sceneLight.range *= scaleW;
        sceneLight.spotAngle *= scaleH;

        peakUp *= scaleH;
        peakDown *= scaleH;

        peakSpotAngle *= scaleW;
        lowSpotAngle *= scaleW;
    }

    // Update is called once per frame
    void Update()
    {
        RectTransform rect = GetComponent<RectTransform>();
        rect.offsetMax = new Vector2(rect.offsetMax.x, -topOffset);
    }

    public void setOffset(Vector2 offsetVector)
    {
        float offsetY = 1 - offsetVector.y;
        offsetY = Mathf.Max(offsetY, 0);
        offsetY = Mathf.Min(offsetY, 1);
        topOffset = (peakTopOffset - lowTopOffset) * offsetY;
    }

    IEnumerator MoveTo()
    {
        while (true)
        {
            // Shake Up
            while (progressed < 1)
            {
                float rotationX = Mathf.Lerp(startX, endX, progressed);
                Vector3 euler = transform.rotation.eulerAngles;
                transform.rotation = Quaternion.Euler(rotationX, euler.y, euler.z);

                float SpotAngle = Mathf.Lerp(startSpotAngle, endSpotAngle, progressed);
                sceneLight.spotAngle = SpotAngle;

                progressed += Time.deltaTime * smoothing;

                yield return new WaitForEndOfFrame();
            }

            //done, cleanup and swap targets        
            progressed = 0f;

            if (!switched)
            {
                startX = -peakUp;
                endX = peakDown;
                startSpotAngle = peakSpotAngle;
                endSpotAngle = lowSpotAngle;
            }
            else
            {
                var temp = endX;
                endX = startX;
                startX = temp;

                temp = endSpotAngle;
                endSpotAngle = startSpotAngle;
                startSpotAngle = temp;

            }

            switched = true;

            yield return new WaitForSeconds(Random.Range(
                defaultPauseBetweenMovements - randomBetweenMovements, 
                defaultPauseBetweenMovements + randomBetweenMovements
                ));

        }
    }
}
