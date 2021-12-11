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
    public float dODBZN;
    private float distToPlayer;
    private float timeBetweenShots;
    public float startTimeBetweenShots;
    public bool directionLeft;
    private Animator animation;
    public Transform bulletSpawn;
    public GameObject player;
    public GameObject coldProjectilePrefab;
    public GameObject hotProjectilePrefab;
    public Rigidbody2D rb;
    public Slider slider;
    public AudioSource iceBulletSound;
    public AudioSource fireBulletSound;
    public Player playerScript;
    public HealthBar healthBar;
    [SerializeField] private Inventory inventory;
    [SerializeField] private SignalObject scoreSignal;
    [SerializeField] private SignalObject temperatureSignal;
    [SerializeField] private Temperature temperature;
    [SerializeField] public EnemyType type;

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

                    if (type == EnemyType.ColdEnemy)
                    {                       
                        projectile = Instantiate(coldProjectilePrefab, bulletSpawn.position, bulletSpawn.rotation);
                        iceBulletSound.Play();
                    }
                    else 
                    {
                        projectile = Instantiate(hotProjectilePrefab, bulletSpawn.position, bulletSpawn.rotation);
                        fireBulletSound.Play();
                    }
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

    public void TakeDamage(int damage)
    { 
        health -= damage;
        healthBar.SetHealth(health);

        if (health <= 0)
        {
            Die();
        }
    }

    public void Die()
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
