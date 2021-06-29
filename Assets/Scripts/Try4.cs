using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Try4 : MonoBehaviour
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
        CubeData cubeData = new CubeData();

        //cubeData.cubePosition = new Vector3(-1, 1, 0);
        //cubeData.Cube = CubeType.white;
        //cubeData.cubePosition = new Vector3(0, 1, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 1, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, 0, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, 0, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 0, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, -1, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, -1, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, -1, 0);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, 1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, 1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, 0, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, 0, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 0, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, -1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, -1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, -1, -1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, 1, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, 1, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 1, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, 0, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, 0, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, 0, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(-1, -1, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(0, -1, 1);
        //cubeData.Cube = CubeType.yellow;
        //cubeData.cubePosition = new Vector3(1, -1, 1);
        //cubeData.Cube = CubeType.yellow;

        string json = File.ReadAllText(Application.dataPath + "/Resources/rubikData.json");
        CubeData loadCubeData = JsonUtility.FromJson<CubeData>(json);
        //Debug.Log(loadCubeData.cubePosition.Length);
        Debug.Log("position:" + loadCubeData.cubePosition);
        //File.WriteAllText(Application.dataPath + "/Resources/rubikData.json", json);
    }


    void Update()
    {

    }

    class CubeData
    {
        public Vector3 cubePosition;
        public CubeType Cube;
    }

    public void SpawnCube(int x, int y, int z, CubeType type)
    {
        var cube = Instantiate(cubePrefab, (new Vector3(x, y, z) * cubeSize), Quaternion.identity);
        // Or whatever you want to do with the type
        cube.GetComponent<Renderer>().material.color = colors[type];
    }
}

//void residue()
//{

//}