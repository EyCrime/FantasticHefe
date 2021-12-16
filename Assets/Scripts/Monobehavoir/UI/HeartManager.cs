using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Inventory playerInventory;

    public void UpdateHearts()
    {
        for (int i = 0; i < playerInventory.maxHealth; i++)
        {
            if(i < playerInventory.currentHealth)
                hearts[i].gameObject.SetActive(true);
            else
            {
                hearts[i].gameObject.SetActive(false);
            }
        }
    }
}
