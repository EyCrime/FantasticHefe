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

   // public float knockDur;
    //public float knockbackPwr;


    // Start is called before the first frame update
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

    // Update is called once per frame
    public void TakeDamage()
    {
        playerInventory.currentHealth--;
        playerHealthSignal.Raise();
        if (playerInventory.currentHealth <= 0)
        {
            Die();
        }
    }

   public void Die()
    {
        gameObject.SetActive(false);
        gameOverSignal.Raise();
    }

     void OnTriggerEnter2D(Collider2D collision)   //von dem kleinen jungen aber man wird nicht nach rechts gesto�en https://www.youtube.com/watch?v=-dMtWZsjX6g
     {
         if (collision.CompareTag("Enemy")) 
         {
            TakeDamage(); 
            Vector3 pushDirection = collision.transform.position - transform.position;

            pushDirection = -pushDirection.normalized;

            GetComponent<Rigidbody2D>().AddForce(pushDirection * force * 100);
            // StartCoroutine(Knockback(knockDur, knockbackPwr, transform.position));
        }
     }

    /*void OnTriggerEnter2D(Collider2D collision)        HAB DAS GENOMMEN YALLLAAAA //sieht clean aus aber man fliegt hoch https://www.youtube.com/watch?v=lGUPG7smpXo
    {
        if (collision.CompareTag("Enemy"))
        {
            TakeDamage(25);

            Vector3 pushDirection = collision.transform.position - transform.position;

            pushDirection = -pushDirection.normalized;

            GetComponent<Rigidbody2D>().AddForce(pushDirection * force * 100);
        }
    }*/

    /* void OnTriggerEnter2D(Collider2D collision)       // funktioniert auch aber h�sslich https://www.youtube.com/watch?v=RE0aWe7ByAI
     {
         if (collision.CompareTag("Enemy"))
         {
             TakeDamage(25);
             Vector2 difference = transform.position - collision.transform.position;
             transform.position = new Vector2(transform.position.x + difference.x, transform.position.y + difference.y);
         }
     }*/

    /* public IEnumerator Knockback(float knockDur, float knockbackPwr, Vector4 knockbackDir)    //von dem kleinen jungen aber man wird nicht nach rechts gesto�en sondern klatscht den gegner nach links https://www.youtube.com/watch?v=-dMtWZsjX6g
     {
         float timer = 0;

         while(knockDur > timer)
         {
             timer += Time.deltaTime;

             rb.AddForce(new Vector4(knockbackDir.x * -100, knockbackDir.y * -100, knockbackDir.x * knockbackPwr, transform.position.z));
         }

         yield return 0;
     }*/
}
