using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMoveAnim : MonoBehaviour
{
    [SerializeField]
    float xDist;

    [SerializeField]
    float yDist;

    public float smoothing = 1f;

    float startX, startY, startZ;
    Transform startPos;
    Vector3 endPos;

    float fraction = 0f;


    // Start is called before the first frame update
    void Start()
    {
        startX = transform.position.x;
        startY = transform.position.y;
        startZ = transform.position.z;
        startPos = transform;
        transform.position = new Vector3(startPos.position.x, startPos.position.y, startPos.position.z);
        endPos =  new Vector3(startX + xDist, startY + yDist, startZ);
    }

    // Update is called once per frame
    void Update()
    {
        //transform.position = Vector3.Lerp(startPos.position, new Vector3(startX + xDist, startY + yDist, startZ), smoothing * Time.deltaTime);
        //transform.position = Vector3.Lerp(new Vector3(startX, startY, startZ), new Vector3(startX + xDist, startY + yDist, startZ), 0.001f * Time.deltaTime);
        StartCoroutine(MoveTo());
    }


    private bool canStart;

    IEnumerator MoveTo()
    {
        // While not there, move
        while (fraction < 1)
        {
            fraction += Time.deltaTime * smoothing;
            transform.position = Vector3.Lerp(startPos.position, endPos, fraction);
            yield return null;
        }

        // done, cleanup and swap targets        
        fraction = 0f;
        canStart = true;

        var tmp = endPos;
        endPos = startPos.position;
        startPos.position = tmp;
    }
}
