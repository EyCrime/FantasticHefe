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
    public GameObject damagePane;
    public float damageTime = 0.5f;
    public float invincibleTime = 0.5f;
    private float nTtGD; // nextTimeToGetDamage
    public float force;
    public Rigidbody2D rb;
    public AudioSource damageSound;

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

    public void TakeDamage()
    {
        if(Time.fixedTime >= nTtGD)
        {
            nTtGD = Time.fixedTime + 1f / invincibleTime;

            playerInventory.currentHealth--;
            if(playerInventory.currentHealth > 0)
            {
                playerHealthSignal.Raise();
                damageSound.Play();
                damagePane.SetActive(true);
                StartCoroutine(DamageCoroutine());
            }
            else
            {
                playerInventory.gameOverReason = "Du hast kein Leben mehr! \nWobei... hattest du auch so nie.";
                Die();
            }
        }
    }

    private IEnumerator DamageCoroutine()
    {
        yield return new WaitForSeconds(damageTime);
        damagePane.SetActive(false);
    }

     public void Die()
    {
        gameObject.SetActive(false);
        gameOverSignal.Raise();
    }
}
