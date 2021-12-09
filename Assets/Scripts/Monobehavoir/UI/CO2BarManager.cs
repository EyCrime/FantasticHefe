using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CO2BarManager : MonoBehaviour
{
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private Slider CO2Slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    private void Start() {
        CO2Slider.maxValue = playerInventory.maxCO2;
        CO2Slider.value = 0;

        fill.color = gradient.Evaluate(0f);
    }

    public void UpdateCO2()
    {
        CO2Slider.value = playerInventory.currentCO2;
        fill.color = gradient.Evaluate(CO2Slider.normalizedValue);
    }
}
