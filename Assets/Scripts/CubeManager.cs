using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeManager : MonoBehaviour
{
    public GameObject Cube;
    public static int row = 5, column = 5, depth = 5;
    GameObject[,,] CubeArray = new GameObject[row,column,depth];
    [SerializeField] float padding;

    void Start()
    {
        for (int x = 0; x < row; x++)
        {
            for (int y = 0; y < column; y++)
            {
                for (int z = 0; z < depth; z++)
                {
                    Vector3 pos = new Vector3(x * padding, y * padding, z * padding);
                    CubeArray[x, y, z] = (GameObject)Instantiate(Cube, pos, transform.rotation);
                    Debug.Log(CubeArray[x, y, x]);
                }
            }
        }
    }
}
   

