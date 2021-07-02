using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text.RegularExpressions;

public class AJVer1 : MonoBehaviour
{
    //Config parameters
    [SerializeField] TextAsset ArrayJSONFile;
    [SerializeField] GameObject cubePrefab;
    [SerializeField] float cubeSize;

    void Start()
    {
        myCubeDataList = JsonUtility.FromJson<CubeDataList>(ArrayJSONFile.text);
        for (int i = 0; i < myCubeDataList.cubeDatas.Length; i++)
        {
            SpawnCube(myCubeDataList.cubeDatas[i].cubePosition, myCubeDataList.cubeDatas[i].Cube);
        }
    }

    //Enum Decalaration for Type of cubes
    //public enum CubeType
    //{
    //    white,
    //    yellow,
    //    blue,
    //    red,
    //    green
    //}

    public enum CubeType
    {
        Apple,
        Avacado,
        Banana,
        Berry,
        CustardApple,
        Grape
    }

    private Dictionary<CubeType, Material> fruits = new Dictionary<CubeType, Material>
    {
         {CubeType.Apple,ResourceLoader.LoadMaterial(CubeType.Apple.ToString())},
         {CubeType.Avacado, ResourceLoader.LoadMaterial(CubeType.Avacado.ToString())},
         {CubeType.Banana, ResourceLoader.LoadMaterial(CubeType.Banana.ToString())},
         {CubeType.Berry, ResourceLoader.LoadMaterial(CubeType.Berry.ToString())},
         {CubeType.CustardApple, ResourceLoader.LoadMaterial(CubeType.CustardApple.ToString())},
         {CubeType.Grape,ResourceLoader.LoadMaterial(CubeType.Grape.ToString())}
    };


    //private readonly IReadOnlyDictionary<CubeType, Color> colors = new Dictionary<CubeType, Color>
    //{
    //    {CubeType.white, Color.white},
    //    {CubeType.yellow, Color.yellow},
    //    {CubeType.blue, Color.blue},
    //    {CubeType.red, Color.red},
    //    {CubeType.green, Color.green}
    //};

    //private readonly IReadOnlyDictionary<CubeType, Material> fruits = new Dictionary<CubeType, Material>
    //{
    //    {CubeType.apple,Fruit.Apple},
    //    {CubeType.avacado, Fruit.Avocado},
    //    {CubeType.banana, Fruit.Banana},
    //    {CubeType.berry, Fruit.Berry},
    //    {CubeType.custardapple, Fruit.Custdapple},
    //    {CubeType.grape,Fruit.Grape}
    //};

    //Spawn Cube Function
    public void SpawnCube(Vector3 pos, CubeType type)
    {
        var cube = Instantiate(cubePrefab, pos * cubeSize, Quaternion.identity);
        // Or whatever you want to do with the type
        cube.GetComponent<Renderer>().material = fruits[type];
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
}
