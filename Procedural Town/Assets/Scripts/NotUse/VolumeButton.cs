using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeButton : MonoBehaviour
{  
    public GameObject Button;
    public GameObject Slider;
    public bool OriginalState;
    
    void Start()
    {
        Slider.SetActive(OriginalState);
    }
    
    public void OnClick()
    {
        Slider.SetActive(!Slider.activeSelf);
        
    }
}
