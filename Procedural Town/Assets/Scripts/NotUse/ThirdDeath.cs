using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ThirdDeath : MonoBehaviour
{
    public GameObject chat;
    public GameObject Death;
    public void OnClick()
    {
        Destroy(chat); 
        Death.SetActive(true); 
    }
}
