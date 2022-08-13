using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChatControl : MonoBehaviour
{
    public GameObject Ghost;
    public GameObject Chat;
    public float distance = 20f;
    Ray ra;
    public Camera ca;
    RaycastHit hit;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ra = ca.ScreenPointToRay(Input.mousePosition);
        if(Physics.Raycast(ra, out hit, distance))
        {
            if(hit.transform.tag == "Ghost" && Input.GetKeyDown(KeyCode.R))
            {
                Chat.SetActive(true);
            }
        }

    }
}
