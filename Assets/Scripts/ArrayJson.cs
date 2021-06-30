using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class ArrayJson : MonoBehaviour
{
    //Config parameters
    [SerializeField] TextAsset ArrayJSONFile;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float cubeSize;

    //Enum Decalaration for Type of cubes
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

    //Spawn Cube Function
    public void SpawnCube(Vector3 pos, CubeType type)
    {
        var cube = Instantiate(cubePrefab, pos * cubeSize, Quaternion.identity);
        // Or whatever you want to do with the type
        cube.GetComponent<Renderer>().material.color = colors[type];
    }

    //Array JSON Read and write
    [System.Serializable]
    public class CubeData
    {
        public Vector3 cubePosition;
        public CubeType Cube;
    }

    [System.Serializable]
    public class CubeDataList
    {
        public CubeData[] cubeDatas;
    }

    public CubeDataList myCubeDataList = new CubeDataList();
    
    void Start()
    {
        myCubeDataList = JsonUtility.FromJson<CubeDataList>(ArrayJSONFile.text);
        for (int i = 0; i < myCubeDataList.cubeDatas.Length; i++)
        {
            SpawnCube(myCubeDataList.cubeDatas[i].cubePosition, myCubeDataList.cubeDatas[i].Cube);   
        }
    }
}
