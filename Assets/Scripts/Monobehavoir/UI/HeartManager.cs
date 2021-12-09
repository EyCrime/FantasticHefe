using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeartManager : MonoBehaviour
{
    [SerializeField] private Image[] hearts;
    [SerializeField] private Inventory playerInventory;
    [SerializeField] private GameObject damagePane;
    [SerializeField] private float damageTime = 0.5f;

    public void UpdateHearts()
    {
        for (int i = 0; i < playerInventory.maxHealth; i++)
        {
            if(i < playerInventory.currentHealth)
                hearts[i].gameObject.SetActive(true);
            else
            {
                hearts[i].gameObject.SetActive(false);
                damagePane.SetActive(true);
                StartCoroutine(DamageCoroutine());
            }
        }
    }

    private IEnumerator DamageCoroutine()
    {
        yield return new WaitForSeconds(damageTime);
        damagePane.SetActive(false);
    }
}
