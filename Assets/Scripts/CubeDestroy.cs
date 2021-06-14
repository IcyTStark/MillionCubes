using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDestroy : MonoBehaviour
{
    [SerializeField] float maxDistance = 10f;
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo, maxDistance))
            {
                if (hitInfo.transform.gameObject.tag == "Cube")
                {
                    Destroy(hitInfo.transform.gameObject);
                }

            }
        }


    }
}
