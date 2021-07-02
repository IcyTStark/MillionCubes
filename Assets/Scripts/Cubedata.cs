using UnityEngine;
public enum CubeType
{
    Apple,
    Avacado,
    Banana,
    Berry,
    CustardApple,
    Grape
}

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

