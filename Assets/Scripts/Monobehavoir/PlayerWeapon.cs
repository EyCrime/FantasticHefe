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
        Instantiate(coldWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        inventory.coldWater--;
        coldWaterSignal.Raise();
    }

    void ShootHotBullet()
    {
        Instantiate(hotWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
        inventory.hotWater--;
        hotWaterSignal.Raise();
    }

    
}
