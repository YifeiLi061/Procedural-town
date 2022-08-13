using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraChange : MonoBehaviour
{
    public Camera cam_all;
    public Camera cam_man;
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            cam_all.enabled = false;
            cam_man.enabled = true;
        }
        if(Input.GetKeyDown(KeyCode.V))
        {
            cam_man.enabled = false;
            cam_all.enabled = true;
        }
    }
}
