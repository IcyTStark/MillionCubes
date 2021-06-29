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
                //Debug.Log(hitInfo.transform.gameObject.name);
                if (hitInfo.collider.tag == "Player")
                {
                    //Destroy(hitInfo.transform.gameObject);
                }
                if(hitInfo.collider.tag == "Gift")
                {
                    Debug.Log("I'm Being poked");
                    hitInfo.transform.gameObject.GetComponent<Animator>().SetBool("open", true);
                }

            }
        }
    }
}
