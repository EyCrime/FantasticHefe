using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;

    public GameObject coldWaterBulletPrefab;
    public GameObject hotWaterBulletPrefab;
    public SignalObject switchAmmoSignal;

    private bool isHotAmmo;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isHotAmmo)
        {
            ShootColdBullet();         
        }

        else if (Input.GetKeyDown(KeyCode.Mouse1) && isHotAmmo)
        {
            ShootHotBullet();
        }

        if (Input.GetKeyDown(KeyCode.P)){
            isHotAmmo = !isHotAmmo;
            switchAmmoSignal.Raise();
        }
    }

    void ShootColdBullet()
    {
        Instantiate(coldWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    void ShootHotBullet()
    {
        Instantiate(hotWaterBulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }

    
}
