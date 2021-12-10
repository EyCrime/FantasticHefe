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

    public GameObject player;
    public Player playerScript;

    public Rigidbody2D rb;

    [SerializeField] private Inventory inventory;
    [SerializeField] private SignalObject scoreSignal;
    [SerializeField] private SignalObject temperatureSignal;
    [SerializeField] private Temperature temperature;

    [SerializeField] public EnemyType type;

    public Slider slider;

    Animator animation;

    private float distToPlayer;

    //  public float speed;
    //public float stoppingDistance;
    //ublic float walkspeed, range;
    //private float distToPlayer;

    public HealthBar healthBar;

    private float timeBetweenShots;
    public float startTimeBetweenShots;

    public GameObject coldProjectilePrefab;
    public GameObject hotProjectilePrefab;

    public float dODBZN;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");

        playerScript = player.GetComponent<Player>();

        timeBetweenShots = startTimeBetweenShots;

        currentHealth = health;
        healthBar.SetMaxHealth(health);

        slider = GetComponentInChildren<Slider>();

        animation = GetComponent<Animator>();
    }
    void Update()
    {
        distToPlayer = Vector2.Distance(transform.position, player.transform.position);

        if (distToPlayer >= range)
        {
            if (type == EnemyType.HotEnemy)
            {
                animation.Play("HotEnemyMovement");
            }
            else if (type == EnemyType.ColdEnemy)
            {
                animation.Play("ColdEnemyMovement");
            }
                
            transform.Translate(2 * Time.deltaTime * speed, 0, 0);
        }
        else
        {
            dODBZN = transform.position.x - player.transform.position.x;  // direction ohne den betrag zu nehmen

            if (type == EnemyType.HotEnemy)
            {
                animation.Play("HotEnemyIdle");
            }
            else if (type == EnemyType.ColdEnemy)
            {
                animation.Play("ColdEnemyIdle");
            }

            // When the player is right to the enemy the value is negative
            if (dODBZN > 0 && !directionLeft || dODBZN < 0 && directionLeft)    
            {              
                Flip();
            }

            if (timeBetweenShots <= 0)
            {
                if(player.activeInHierarchy) { 

                    GameObject projectile;

                     var myTransform = transform;
                     myTransform.Rotate(Vector3.forward, 180);

                    if(type == EnemyType.ColdEnemy)
                        projectile = Instantiate(coldProjectilePrefab, bulletSpawn.position, bulletSpawn.rotation);
                    else
                        projectile = Instantiate(hotProjectilePrefab, bulletSpawn.position, bulletSpawn.rotation);

                    if(directionLeft)
                    {
                        Vector3 theScale = transform.localScale;
                        theScale.x *= -1;
                        projectile.transform.localScale = theScale;
                    }
                    

                    Rigidbody2D rbProjectile = projectile.GetComponent<Rigidbody2D>();
                    Vector2 startPosition = projectile.transform.position;
                    Vector2 target = new Vector2(player.transform.position.x, player.transform.position.y);
                    rbProjectile.AddForce((target - startPosition).normalized * speed, ForceMode2D.Impulse);
                }
                timeBetweenShots = startTimeBetweenShots;
            }
            else
            {
                timeBetweenShots -= Time.deltaTime;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Turn"))
        {
            Flip();
        }
        else if (collision.CompareTag("Player"))
        {
            rb.bodyType = RigidbodyType2D.Static;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        rb.bodyType = RigidbodyType2D.Dynamic;
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
        if (type == EnemyType.HotEnemy)
        {
            temperature.current--;
            temperatureSignal.Raise();
        }
        else if (type == EnemyType.ColdEnemy)
        {
            temperature.current++;
            temperatureSignal.Raise();
        }

        if ((temperature.current <= temperature.min) || (temperature.current >= temperature.max))
        {
            playerScript.Die();
        }
     
        inventory.score += 20;
        scoreSignal.Raise();
        Destroy(gameObject);
    }  
}

public enum EnemyType
{
    HotEnemy, ColdEnemy
}
