using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject coldWaterBulletPrefab;
    public GameObject projectilePrefab;
    public GameObject hotWaterBulletPrefab;
    public Inventory inventory;
    public SignalObject switchAmmoSignal;
    public SignalObject coldWaterSignal;
    public SignalObject hotWaterSignal;
    public SignalObject co2Signal; 
    private bool isHotAmmo;
    public bool directionRight;
    public float speed = 20f;
    public float bombSpeed = 10f;
    public float fireRate = .5f;
    private float nextTimeToShoot;
    public AudioSource waterBulletSound;
    public AudioSource hotBulletSound;
    public AudioSource throwSound;

    // Update is called once per frame
    private void Update()
    {
        if (Time.timeScale != 0f)
        {
            if(Input.GetKeyDown(KeyCode.Mouse1))
            {
                if(inventory.currentCO2==inventory.maxCO2)
                {
                    ShootBomb();
                    throwSound.Play();
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                isHotAmmo = !isHotAmmo;
                switchAmmoSignal.Raise();
            }

            if(Input.GetKeyDown(KeyCode.Mouse0) && Time.time >= nextTimeToShoot)
            {
                nextTimeToShoot = Time.time + 1f / fireRate;
                if (!isHotAmmo && inventory.coldWater > 0)
                {
                    ShootColdBullet();
                    waterBulletSound.Play();
                }
                else if (isHotAmmo && inventory.hotWater > 0)
                {
                    ShootHotBullet();
                    hotBulletSound.Play();
                }
            }
        }
    }

    void ShootColdBullet()
    {
        GameObject coldBullet = Instantiate(coldWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if (directionRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            coldBullet.transform.localScale = theScale;
        }

        Rigidbody2D rbCold = coldBullet.GetComponent<Rigidbody2D>();
        if (directionRight)
        {
            rbCold.velocity = -transform.right * speed;
        }
        else
        {
            rbCold.velocity = transform.right * speed;
        }
        inventory.coldWater--;
        coldWaterSignal.Raise();
        
    }
    
    void ShootHotBullet()
    { 
        GameObject hotBullet = Instantiate(hotWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);       

        if (directionRight)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            hotBullet.transform.localScale = theScale;
        }

        Rigidbody2D rbHot = hotBullet.GetComponent<Rigidbody2D>();
        if (directionRight)
        {
            rbHot.velocity = -transform.right* speed;
        }
        else
        {
            rbHot.velocity = transform.right * speed;
        }
        inventory.hotWater--;
        hotWaterSignal.Raise();
        
    }

    void ShootBomb()
    {
        GameObject bomb = Instantiate(projectilePrefab, bulletSpawn.position, transform.rotation);
        Rigidbody2D rbBomb = bomb.GetComponent<Rigidbody2D>();
         if (directionRight)
        {
            rbBomb.velocity = -(transform.right + Vector3.down) * bombSpeed;
        }
        else
        {
            rbBomb.velocity = (transform.right + Vector3.up) * bombSpeed;
        }
        inventory.currentCO2 = 0;
        co2Signal.Raise();
    }

    public void ChangeDirection()
    {
        directionRight = !directionRight;
    }
}
