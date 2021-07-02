using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class JSONWriter
{
    public static void SaveData(string location, CubeDataList cubeDataList)
    {      
        string strOutput = JsonUtility.ToJson(cubeDataList);
        if(File.Exists(location))
        {
            File.Delete(location);
        }
        File.WriteAllText(location, strOutput);
    }

    public static CubeDataList LoadData(string location)
    {
        if (!File.Exists(location)) return null;

        string loc = File.ReadAllText(location);
        CubeDataList data = JsonUtility.FromJson<CubeDataList>(loc);
        return data;
    }

}


