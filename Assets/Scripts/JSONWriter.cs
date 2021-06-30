using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter : MonoBehaviour
{
    [SerializeField] int rows, columns, depth , minDepth , minColumn , minRow;
    [SerializeField] float padding;
    public enum CubeType
    {
        white,
        yellow,
        blue,
        red,
        green
    }
    CubeType cubeType;

    private readonly IReadOnlyDictionary<CubeType, Color> colors = new Dictionary<CubeType, Color>
    {
        {CubeType.white, Color.white},
        {CubeType.yellow, Color.yellow},
        {CubeType.blue, Color.blue},
        {CubeType.red, Color.red},
        {CubeType.green, Color.green}
    };

    //Spawn Cube Function
    //public void SpawnCube(Vector3 pos, CubeType type)
    //{
    //    var cube = Instantiate(cubePrefab, pos * cubeSize, Quaternion.identity);
    //    // Or whatever you want to do with the type
    //    cube.GetComponent<Renderer>().material.color = colors[type];
    //}

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
        //public List<CubeData> cubeDatas;
    }

    public void outputJSON()
    {
        string strOutput = JsonUtility.ToJson(myCubeDataList);
        File.WriteAllText(Application.dataPath + "/Resources/10x10x10.txt", strOutput);
    }

    //CubeData myCubeData = new CubeData();
    public CubeDataList myCubeDataList = new CubeDataList();
   
    
    void Start()
    {
        for (int x = 0; x < myCubeDataList.cubeDatas.Length; x++)
        {
            for (int i = minDepth; i < depth; i++)
            {
                for (int j = minColumn; j < columns; j++)
                {
                    for (int k = minRow; k < rows; k++)
                    {
                        myCubeDataList.cubeDatas[x].cubePosition = new Vector3(i, j, k) * padding;
                        myCubeDataList.cubeDatas[x].Cube = (CubeType)Random.Range(0, System.Enum.GetValues(typeof(CubeType)).Length);
                        x++;
                    }
                }
            }
        }
    }
}


