using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float pitch = 2f;
    private float currentZoom = 10f;

    public float zoomSpeed = 4f;
    public float maxZoom = 15f;
    public float minZoom = 5f;
    // Start is called before the first frame update
    void Update()
    {
        currentZoom += Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;
        currentZoom = Mathf.Clamp(currentZoom, minZoom, maxZoom);
    }


    
    /*void LateUpdate()
    {
        transform.position = target.position - offset * currentZoom;
        transform.LookAt(target.position + Vector3.up * pitch );
    }*/

}