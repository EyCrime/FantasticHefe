using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private FloatValue heartContainers;
    [SerializeField] private FloatValue playerCurrentHealth;
    
    private void Start() {
        InitHearts();    
    }

    public void InitHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }
    }

    public void UpdateHearts()
    {
        for (int i = 0; i < heartContainers.initialValue; i++)
        {
            if(i < playerCurrentHealth.runtimeValue)
                hearts[i].gameObject.SetActive(true);
            else
                hearts[i].gameObject.SetActive(false);
        }
    }
}
