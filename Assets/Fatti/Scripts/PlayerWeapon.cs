using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    public Transform bulletSpawn;
    public GameObject bulletPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
        
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, bulletSpawn.position, bulletSpawn.rotation);
    }
}
