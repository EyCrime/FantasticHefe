using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int health = 100;
    public int currentHealth;
    public float speed;
    public float range;
    public bool directionLeft;

    public Transform bulletSpawn;

    public Slider slider;

    private float distToPlayer;
    public Transform player;

    //  public float speed;
    //public float stoppingDistance;
    //ublic float walkspeed, range;
    //private float distToPlayer;

    public HealthBar healthBar;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject projectile;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        timeBetweenShots = startTimeBetweenShots;

        currentHealth = health;
        healthBar.SetMaxHealth(health);

        slider = GetComponentInChildren<Slider>();
    }
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer >= range)
        {
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }

        else
        {
            if (timeBetweenShots <= 0)
            {
                Instantiate(projectile, bulletSpawn.position, bulletSpawn.rotation);
                timeBetweenShots = startTimeBetweenShots;

            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D trig)
    {
        if (trig.gameObject.CompareTag("turn"))
        {
            Flip();
        }
    }

    private void Flip()
    {
        directionLeft = !directionLeft;
        Vector3 theScale = transform.localScale;
        theScale.x *= -1;
        transform.localScale = theScale;
        speed *= -1;

        if (directionLeft)
        {
            slider.direction = Slider.Direction.RightToLeft;

        }
        else
        {
            slider.direction = Slider.Direction.LeftToRight;
        }
    }

    /* void Update()
     {
         if (Vector2.Distance(transform.position, player.position) > stoppingDistance)
         {

         }
         else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
         {
             transform.position = this.transform.position;

         }

         if (timeBetweenShots <= 0)
         {
             Instantiate(projectile, transform.position, Quaternion.identity);
             timeBetweenShots = startTimeBetweenShots;

         }
         else
         {

             timeBetweenShots -= Time.deltaTime;

         }

     }*/

    /*void Update()                 allllt wo er einen verfolgt
    {
        if(Vector2.Distance(transform.position, player.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        } else if (Vector2.Distance(transform.position, player.position) < stoppingDistance)
        {
            transform.position = this.transform.position;

        }

        if (timeBetweenShots <= 0)
        {
            Instantiate(projectile, transform.position, Quaternion.identity);
            timeBetweenShots = startTimeBetweenShots;

        } else {

            timeBetweenShots -= Time.deltaTime;
            
        }

    }*/

    public void TakeDamage(int damage)
    {
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Destroy(gameObject);
    }
    
}
