using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon2 : MonoBehaviour
{
    public Transform bulletSpawn;

    public Inventory inventory;

    public GameObject coldWaterBulletPrefab;
    public GameObject hotWaterBulletPrefab;
    public GameObject co2BombPrefab;

    public SignalObject switchAmmoSignal;
    public SignalObject coldWaterSignal;
    public SignalObject hotWaterSignal;
    public SignalObject co2Signal;

    private bool isHotAmmo;

    private void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
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

        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            isHotAmmo = !isHotAmmo;
            switchAmmoSignal.Raise();
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            ShootBomb();
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

    void ShootBomb()
    {
        //Instantiate();
        inventory.currentCO2 = 0;
        co2Signal.Raise();
    }


}
