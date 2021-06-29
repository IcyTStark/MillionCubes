using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class CSVReader : MonoBehaviour
{
    [SerializeField] string DataName;
    
    void Start()
    {
        var result = ParseCSV("Assets/Resources/" + DataName + ".csv");

        //foreach (var line in result)
        //{
        //    foreach (var col in line)
        //    {
        //        // process the data
        //    }
        //}
    }

    private static object ParseCSV(string file)
    {
        string text = File.ReadAllText(file);       //Read the whole file and store it in text
        Debug.Log("text:" + text);
        string[] line = Regex.Split(text, "\r\n");    //Split line by line
        int row = line.Length;                      //Store as row and pass on to levelbase
        Debug.Log("row:" + row);
        string[][] levelbase = new string[row][];
        for (int i = 0; i < row; i++)
        {
            string[] stringLine = Regex.Split(line[i], ","); //split one by one individual string line by line
            levelbase[i] = stringLine;
            //Debug.Log(stringLine);
        }

        return levelbase;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
