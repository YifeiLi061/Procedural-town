using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextChat : MonoBehaviour
{
    public GameObject Next;
    public GameObject First;
    // Start is called before the first frame update
    public void OnClick()
    {
        Next.SetActive(true); 
        Destroy(First); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
