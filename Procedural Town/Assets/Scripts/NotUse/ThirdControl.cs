using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdControl : MonoBehaviour
{
    public GameObject Next;
    public GameObject Third1;
    public GameObject Third2;
    public GameObject Fire;
 
    // Start is called before the first frame update
    public void OnClick()
    {
        if(Fire.activeSelf == true)
        {
            Third1.SetActive(true); 
            Destroy(Next); 
        }
        else
        {
            Third2.SetActive(true); 
            Destroy(Next);            
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
