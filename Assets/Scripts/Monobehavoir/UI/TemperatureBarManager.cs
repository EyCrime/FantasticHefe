using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TemperatureBarManager : MonoBehaviour
{
    [SerializeField] private Temperature temperature;
    [SerializeField] private Slider temperatureSlider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Start() {
        temperatureSlider.maxValue = temperature.max;
        temperatureSlider.value = temperature.current;

        fill.color = gradient.Evaluate(0.5f);
    }

    public void UpdateTemperature()
    {
        temperatureSlider.value = temperature.current;
        fill.color = gradient.Evaluate(temperatureSlider.normalizedValue);
    }
}
