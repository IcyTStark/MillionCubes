using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceLoader
{
    public static Material LoadMaterial(string name)
    {
        Material m = Resources.Load("FruitMat/" + name) as Material;
        return m;
    }
}
