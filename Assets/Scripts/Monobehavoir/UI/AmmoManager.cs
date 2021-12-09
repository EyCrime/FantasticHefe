using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField] private GameObject coldWaterHighlighter;
    [SerializeField] private GameObject hotWaterHighlighter;
    [SerializeField] private bool hotWaterActive;

    public void ChangeAmmo()
    {
        if(hotWaterActive)
        {
            hotWaterHighlighter.SetActive(false);
            coldWaterHighlighter.SetActive(true);
        }
        else {
            hotWaterHighlighter.SetActive(true);
            coldWaterHighlighter.SetActive(false);
        }
        hotWaterActive = !hotWaterActive;
    }
}
