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
    private bool isHotAmmo;

    public float speed = 20f;

    public bool directionRight;

    // Update is called once per frame
    void Update()
    {
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

    public void ChangeDirection()
    {
        directionRight = !directionRight;

     }

}
