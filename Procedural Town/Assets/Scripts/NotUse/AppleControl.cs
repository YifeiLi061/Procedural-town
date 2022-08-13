using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppleControl : MonoBehaviour
{
    public GameObject Apple;
    public GameObject Magic;
    public GameObject ghost;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Apple)
        {
            Destroy(other.gameObject);
            Magic.SetActive(true);
            ghost.SetActive(true);
        }
    }
}
