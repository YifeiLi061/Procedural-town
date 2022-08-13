using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpWeapon : MonoBehaviour
{
    public Transform equipPosition;
    public float distance = 10f;
    GameObject currentWeapon;
    GameObject wp;

    bool canGrab;
    Ray ra;
    public Camera ca;
    RaycastHit hit;
    

    private void Update()
    {
        CheckWeapons();

        if(canGrab)
        {
            if(Input.GetKeyDown(KeyCode.E))
            {
                if(currentWeapon != null)
                    Drop();
                
                PickUp();
            }
        }
        if(currentWeapon != null)
        {
            if(Input.GetKeyDown(KeyCode.Q))
               Drop();
        }
    }

    private void CheckWeapons()
    {
        ra = ca.ScreenPointToRay(Input.mousePosition);

        if(Physics.Raycast(ra, out hit, distance))
        {
            if(hit.transform.tag == "CanGrab")
            {
                canGrab = true;
                wp = hit.transform.gameObject;

            }
        }
        else
        {
            canGrab = false;
        }
    }

    private void PickUp()
    {
        currentWeapon = wp;
        currentWeapon.transform.position = equipPosition.position;
        currentWeapon.transform.parent = equipPosition;
        currentWeapon.transform.localEulerAngles = new Vector3(90f, 180f, 0f);
        currentWeapon.GetComponent<Rigidbody>().isKinematic = true;
    }

    private void Drop()
    {
        currentWeapon.transform.parent = null;
        currentWeapon.GetComponent<Rigidbody>().isKinematic = false;
        currentWeapon = null;
    }

    /*void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            
            Destroy (gameObject);
        }
    }*/
}
