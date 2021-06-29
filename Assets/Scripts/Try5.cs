using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class Try5 : MonoBehaviour
{
    public enum CubeType
    {
        white,
        yellow,
        blue,
        red,
        green
    }

    private readonly IReadOnlyDictionary<CubeType, Color> colors = new Dictionary<CubeType, Color>
    {
        {CubeType.white, Color.white},
        {CubeType.yellow, Color.yellow},
        {CubeType.blue, Color.blue},
        {CubeType.red, Color.red},
        {CubeType.green, Color.green}
    };

    [SerializeField] GameObject cubePrefab;
    [SerializeField] float cubeSize = 1f;

    void Start()
    {
        //string[][] CubeLoader = ReadFile(Application.dataPath + "/Resources/rubikData.json");
        //string json = File.ReadAllText(Application.dataPath + "/Resources/rubikData.json");
        //Debug.Log(json.Length);

        //string json = File.ReadLines(Application.dataPath + "/Resources/rubikData.json",System.Text.Encoding.Default);
        //var storeData = JsonUtility.FromJson<CubeData>(json);
        //for (int i = 0; i < json.Length; i++)
        //{
        //    //Debug.Log(json.Length);
        //    SpawnCube(storeData.cubePosition, storeData.Cube);
        //}

        foreach (string line in File.ReadLines(Application.dataPath + "/Resources/rubikData.json"))
        {
            var storeData = JsonUtility.FromJson<CubeData>(line.Trim());
            for (int i = 0; i < line.Length; i++)
            {
                //Debug.Log(json.Length);
                SpawnCube(storeData.cubePosition, storeData.Cube);
            }
        }
    }

    [System.Serializable]
    class CubeData
    {
        public Vector3 cubePosition;
        public CubeType Cube;
    }

    public void SpawnCube(Vector3 pos, CubeType type)
    {
        var cube = Instantiate(cubePrefab, (pos * cubeSize), Quaternion.identity);
        // Or whatever you want to do with the type
        cube.GetComponent<Renderer>().material.color = colors[type];
    }

    string[][] ReadFile(string file)
    {
        string text = File.ReadAllText(file);       //Read the whole file and store it in text
        Debug.Log("text:" + text);
        string[] line = Regex.Split(text, "\r\n");    //Split line by line
        int row = line.Length;                      //Store as row and pass on to levelbase
        //Debug.Log("row:" + row);
        string[][] levelbase = new string[row][];
        //for (int i = 0; i < row; i++)
        //{
        //    string[] stringLine = Regex.Split(line[i], "/"); //split one by one individual string line by line
        //    levelbase[i] = stringLine;
        //    Debug.Log(stringLine);
        //}

        return levelbase;
    }
}

