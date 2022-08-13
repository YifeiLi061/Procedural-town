using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireControl : MonoBehaviour
{
    public GameObject Fire;
    public GameObject Wine;
    // Start is called before the first frame update
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == Wine)
        {
            Fire.SetActive(true);
        }
    }
}
