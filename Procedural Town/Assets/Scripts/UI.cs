using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    public Text obsPercent;
    public Text outlinePercent;
    public Slider obsSlider;
    public Slider outSlider;
    public InputField x;
    public InputField y;
    public InputField r;
    // Start is called before the first frame update
    public void ObsSlider()
    {
        mapGenerator.obsPercent = obsSlider.value;
        obsPercent.text = mapGenerator.obsPercent.ToString();
    }
    public void OutlineSlider()
    {
        mapGenerator.outlinePercent = outSlider.value;
        outlinePercent.text = mapGenerator.outlinePercent.ToString();
    }

    public void MapSizeX()
    {
        string inputFieldText;
        int result;
        inputFieldText = x.text;
        result = Convert.ToInt32(inputFieldText);
        mapGenerator.mapSize.x = result;
    }

    public void MapSizeY()
    {
        string inputFieldText;
        int result;
        inputFieldText = y.text;
        result = Convert.ToInt32(inputFieldText);
        mapGenerator.mapSize.y = result;
    }

    public void MapRotateR()
    {
        string inputFieldText;
        int result;
        inputFieldText = r.text;
        result = Convert.ToInt32(inputFieldText);
        mapGenerator.Rotation = result;
    }
}
