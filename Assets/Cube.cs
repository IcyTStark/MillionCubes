using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cube : MonoBehaviour
{
    private void Start()
    {
        GameManager.Instance.cubes.Add(gameObject);
    }
    private void OnDestroy()
    {
        GameManager.Instance.cubes.Remove(gameObject);
    }
}
