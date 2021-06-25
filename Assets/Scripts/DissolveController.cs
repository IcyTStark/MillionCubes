using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveController : MonoBehaviour
{
    Material material;
    
    float v = 0.0f;
    [SerializeField] float dissolveSpeed = 1f;
    void Start()
    {
        var renderer = GetComponent<MeshRenderer>();
        material = Instantiate(renderer.sharedMaterial);
        renderer.material = material;
        
    }

    private void OnDestroy()
    {
        if(material != null)
        {
            Destroy(material);
        }
    }
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hitInfo;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hitInfo))
            {
                if(hitInfo.collider.tag == "Player")
                {
                    StartCoroutine(SmoothMove(1f,hitInfo));
                }
            }
        }
    }

    IEnumerator SmoothMove(float endpos, RaycastHit hitthing)
    {
        float t = 0f;
        while(t<=1.0)
        {
            t += Time.deltaTime / dissolveSpeed;
            material.SetFloat("_DissolveSlider", Mathf.Lerp(v, endpos, Mathf.SmoothStep(0f, 1f, t)));
            Destroy(hitthing.transform.gameObject ,1.5f);
            yield return null;
        }
    }
}
