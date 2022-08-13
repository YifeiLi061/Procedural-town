using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DestroyChat : MonoBehaviour
{
    public GameObject Third1;
    // Start is called before the first frame update
    public void OnClick()
    {
        Destroy(Third1); 
    }
       
}
