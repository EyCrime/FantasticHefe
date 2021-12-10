using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureBarManager : MonoBehaviour
{
    [SerializeField] private Temperature temperature;
    [SerializeField] private Sprite[] thermometerSprites;
    [SerializeField] private Image currentImage;

    private void Start() {    
        currentImage.sprite = thermometerSprites[temperature.normal];
    }

    public void UpdateTemperature()
    {
        currentImage.sprite = thermometerSprites[temperature.current];
    }
}
