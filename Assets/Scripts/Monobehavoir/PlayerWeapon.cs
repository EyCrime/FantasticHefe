using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;
    public Inventory inventory;
    public GameObject coldWaterBulletPrefab;
    public GameObject hotWaterBulletPrefab;
    public SignalObject switchAmmoSignal;
    public SignalObject coldWaterSignal;
    public SignalObject hotWaterSignal;
    public GameObject projectilePrefab;
    public SignalObject co2Signal; 
    private bool isHotAmmo;

    public float speed = 20f;
    public float bombSpeed = 10f;

    public bool directionRight;

    // Update is called once per frame
    void Update()
    {
         if(Input.GetKeyDown(KeyCode.Mouse1))
         {
             if(inventory.currentCO2==inventory.maxCO2)
             
             {
                 ShootBomb();
             }
         }

        if(Input.GetKeyDown(KeyCode.Mouse0))
        {
            if (!isHotAmmo && inventory.coldWater > 0)
            {
                ShootColdBullet();         
            }
            else if (isHotAmmo && inventory.hotWater > 0)
            {
                ShootHotBullet();
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)){
            isHotAmmo = !isHotAmmo;
            switchAmmoSignal.Raise();
        }
    }

    void ShootColdBullet()
    {

        GameObject coldBullet = Instantiate(coldWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);

        if(directionRight)
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

        if(directionRight)
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
