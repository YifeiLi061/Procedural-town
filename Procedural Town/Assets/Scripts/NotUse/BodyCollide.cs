using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BodyCollide : MonoBehaviour
{
    private int groundLayerIndex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        groundLayerIndex = LayerMask.GetMask("Ground");
    }

    void FixedUpdate()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 200, groundLayerIndex))
        {
            Vector3 target = hitInfo.point;
            target.y = transform.position.y;
            transform.LookAt(target);
        }

    }

    // Update is called once per frame
    /*void Update () 
    {
        RaycastHit hit;
        Vector3 p1 = transform.position;
        Vector3 p2 = p1 + Vector3.forward * 0.5f;
        if(Physics.CapsuleCast(p1, p2, 0.0f, transform.forward, out hit, 0.2f))
        {
            
            CActionControl.Instance().OnStopMove(uqid_);
        }
    }*/
}
