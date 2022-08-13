using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    public GameObject MessagePanel;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenMessagePanel(string text)
    {
        MessagePanel.SetActive(true);

    }

    public void CloseMessagePanel(string text)
    {
        MessagePanel.SetActive(false);

    }
}
