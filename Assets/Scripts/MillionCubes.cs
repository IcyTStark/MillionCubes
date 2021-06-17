using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MillionCubes : MonoBehaviour
{
    [SerializeField] GameObject cubePrefab;
    [SerializeField] GameObject parentforCubes;
    
    [SerializeField] int rows, columns, depth;
    [SerializeField] float padding;
    void Start()
    {
        for (int i = 0; i < depth; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                for (int k = 0; k < rows; k++)
                {
                    Vector3 pos = new Vector3(k * padding, j * padding, i * padding);
                    var spawn = (GameObject)Instantiate(cubePrefab, pos, Quaternion.identity);
                    spawn.transform.parent = parentforCubes.transform;
                }
            }
        }
    }
}
