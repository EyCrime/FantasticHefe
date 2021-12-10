using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Inventory playerInventory;
    public Temperature temperature;
    public SignalObject playerHealthSignal;
    public SignalObject startTimerSignal;
    public SignalObject gameOverSignal;
    public SignalObject coldWaterSignal;
    public SignalObject hotWaterSignal;
    public SignalObject scoreSignal;
    public SignalObject CO2Signal;
    public SignalObject temperatureSignal;

    public float force;

    public Rigidbody2D rb;

    public AudioSource damageSound;
    public AudioSource deathSound;

    void Start()
    {
        playerInventory.currentHealth = playerInventory.maxHealth;
        playerInventory.currentCO2 = 0;
        playerInventory.coldWater = 0;
        playerInventory.hotWater = 0;
        playerInventory.score = 0;
        temperature.current = temperature.normal;
        startTimerSignal.Raise();
        playerHealthSignal.Raise();
        coldWaterSignal.Raise();
        hotWaterSignal.Raise();
        scoreSignal.Raise();
        CO2Signal.Raise();
        temperatureSignal.Raise();
    }

    public void TakeDamage()
    {
        playerInventory.currentHealth--;
        playerHealthSignal.Raise();
        if(playerInventory.currentHealth >= 1)
        {
            damageSound.Play();
        }
        if (playerInventory.currentHealth <= 0)
        {
            Die();
        }
    }

   public void Die()
    {
        deathSound.Play();
        gameObject.SetActive(false);
        gameOverSignal.Raise();
    }

     void OnTriggerEnter2D(Collider2D collision)
     {
         if (collision.CompareTag("Enemy")) 
         {
            TakeDamage(); 
            Vector3 pushDirection = collision.transform.position - transform.position;

            pushDirection = -pushDirection.normalized;

            GetComponent<Rigidbody2D>().AddForce(pushDirection * force * 100);
        }
     }
}
