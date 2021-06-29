using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeTry3 : MonoBehaviour
{
    // Size/Expands of one cube tile
    public float cubeSize = 1f;
    public GameObject prefab;
    // Amount of layers/dimensions e.g. 3x3
    public int dimensions = 3;

    void Start()
    {
        SpawnCube(-1, 1, 0, CubeType.yellow);
        SpawnCube(0, 1, 0, CubeType.blue);
        SpawnCube(1, 1, 0, CubeType.green);
        SpawnCube(-1, 0, 0, CubeType.red);
        SpawnCube(0, 0, 0, CubeType.white);
        SpawnCube(1, 0, 0, CubeType.yellow);
        SpawnCube(-1, -1, 0, CubeType.blue);
        SpawnCube(0, -1, 0, CubeType.green);
        SpawnCube(1, -1, 0, CubeType.red);
        SpawnCube(-1, 1, -1, CubeType.white);
        SpawnCube(0, 1, -1, CubeType.yellow);
        SpawnCube(1, 1, -1, CubeType.red);
        SpawnCube(-1, 0, -1, CubeType.white);
        SpawnCube(0, 0, -1, CubeType.yellow);
        SpawnCube(1, 0, -1, CubeType.green);
        SpawnCube(-1, -1, -1, CubeType.blue);
        SpawnCube(0, -1, -1, CubeType.yellow);
        SpawnCube(1, -1, -1, CubeType.white);
        SpawnCube(-1, 1, 1, CubeType.red);
        SpawnCube(0, 1, 1, CubeType.blue);
        SpawnCube(1, 1, 1, CubeType.red);
        SpawnCube(-1, 0, 1, CubeType.yellow);
        SpawnCube(0, 0, 1, CubeType.green);
        SpawnCube(1, 0, 1, CubeType.blue);
        SpawnCube(-1, -1, 1, CubeType.yellow);
        SpawnCube(0, -1, 1, CubeType.red);
        SpawnCube(1, -1, 1, CubeType.yellow);
    }

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

    public void SpawnCube(int x, int y, int z, CubeType type)
    {
        var cube = Instantiate(prefab, (new Vector3(x, y, z) * cubeSize), Quaternion.identity);
        // Or whatever you want to do with the type
        cube.GetComponent<Renderer>().material.color = colors[type];
    }
}


//-Vector3.one * dimensions / 2f)