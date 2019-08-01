using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class StoryController : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
        TMP_Text textComponent = GetComponent<TMP_Text>();

        string text = System.IO.File.ReadAllText(Application.dataPath +"/chapter01.txt");
        textComponent.SetText(text);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
