using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory playerInventory;
    public SignalObject playerHealthSignal;
    public SignalObject startTimerSignal;
    public SignalObject stopTimerSignal;

    // Start is called before the first frame update
    void Start()
    {
        startTimerSignal.Raise();
        playerInventory.currentHealth = playerInventory.maxHealth;
        playerHealthSignal.Raise();
    }

    // Update is called once per frame
    public void TakeDamage(int damage)
    {
        playerInventory.currentHealth--;
        playerHealthSignal.Raise();
        if (playerInventory.currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        gameObject.SetActive(false);
        stopTimerSignal.Raise();
    }
}
