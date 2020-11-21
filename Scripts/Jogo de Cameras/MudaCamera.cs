using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MudaCamera : MonoBehaviour
{
    public Camera[] cameras;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(CicloCameras());
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DesativaCameras()
    {
        for (int i = 0; i < cameras.Length; i++)
        {
            cameras[i].gameObject.SetActive(false);
        }
    }

    IEnumerator CicloCameras()
    {

        yield return null;
    }
}
