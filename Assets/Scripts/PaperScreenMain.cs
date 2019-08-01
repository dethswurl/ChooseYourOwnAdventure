using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.Events;

public class PaperScreenMain : MonoBehaviour
{
    public string filename;
    public string fileText;

    public void CreateTxtFile()
    {
        if (filename.Equals("")) return;


        //Path of File
        string path = Application.dataPath + "/" +filename;

        //Check if file exists
        if (File.Exists(path))
        {
            //If it does, try again with a 1 after it
            //filename = filename + "_1";
            //CreateTxtFile();
            return;
        }else 
        {
            //If it doesn't exist, make itttt
            File.WriteAllText(path, fileText);
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        CreateTxtFile();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
