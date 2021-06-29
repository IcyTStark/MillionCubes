using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Try2 : MonoBehaviour
{
    //config parameters // 1 - StartingPoint, 2 - Rails, 3 - Destination
    [Header("Assets to Use:")]
    [SerializeField] GameObject Cube;
    //[SerializeField] GameObject Rails;
    //[SerializeField] GameObject Destination;

    [Header("Level Details:")]
    [SerializeField] string DataName;


    void Start()
    {
        string[][] CubeLoader = ReadFile("Assets/Resources/" + DataName + ".csv");
        var Stringthing = StringToVector3("Assets/Resources/" + DataName + ".csv");
        Debug.Log(Stringthing);
        //Debug.Log("CubeLoader.Length:" + CubeLoader.Length);
        //for (int i = 0; i < CubeLoader.Length; i++)
        //{
        //    Instantiate(Cube, i, Quaternion.identity);
        //}

        //foreach (Vector3 node in Stringthing)
        //{
           
        //        var something = float.Parse(node);
        //        Vector3 some1 = new Vector3(something,something,something);
        //        {
        //            Instantiate(Cube, some1, Quaternion.identity);
        //        }
            
        //}
    }
    string[][] ReadFile(string file)
    {
        string text = File.ReadAllText(file);       //Read the whole file and store it in text
        //Debug.Log("text:" + text);
        string[] line = Regex.Split(text, "\r\n");    //Split line by line
        int row = line.Length;                      //Store as row and pass on to levelbase
        //Debug.Log("row:" + row);
        string[][] levelbase = new string[row][];
        for (int i = 0; i < row; i++)
        {
            string[] stringLine = Regex.Split(line[i], ","); //split one by one individual string line by line
            levelbase[i] = stringLine;
            //Debug.Log(stringLine);
        }

        return levelbase;
    }

    public Vector3 StringToVector3(string file)
    {
        // Remove the parentheses
        if (file.StartsWith("(") && file.EndsWith(")"))
        {
            file = file.Substring(1, file.Length - 2);
        }
        Debug.Log(file);
        // split the items
        string[] sArray = file.Split(',');

        // store as a Vector3
        Vector3 result = new Vector3(float.Parse(sArray[0]),float.Parse(sArray[1]),float.Parse(sArray[2]));
        Debug.Log(result);
        return result;
    }
}

//void residue()
//{
//    for (int z = 0; z < CubeLoader[x].Length; z++)
//    {
//        switch (CubeLoader[x][z].Trim())
//        {
//            case "1":
//                Instantiate(StartingPoint, new Vector3(x, 1.5f, z), Quaternion.identity);
//                break;
//            case "2":
//                GameObject rails = Instantiate(Rails, new Vector3(x, 1.95f, z), Quaternion.identity);
//                //var RailsLocation = rails.gameObject.transform.GetChild(0);
//                //GameManager.Instance.points.Add(RailsLocation);
//                break;
//            case "3":
//                Instantiate(Destination, new Vector3(x, 1.5f, z), Quaternion.identity);
//                break;


//        }
//    }
//}
