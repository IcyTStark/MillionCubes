using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class CubeDestroy : MonoBehaviour
{
    private void Start()
    {
        
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if (hitInfo.collider.tag == "Player")
                {
                    //Destroy(hitInfo.transform.gameObject);
                }

            }
        }
    }
}
