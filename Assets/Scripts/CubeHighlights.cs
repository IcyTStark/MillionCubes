using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeHighlights : MonoBehaviour
{
   public static CubeHighlights Instance { set; get; }

    public GameObject highlightPrefab;
    private List<GameObject> highlights;
}
