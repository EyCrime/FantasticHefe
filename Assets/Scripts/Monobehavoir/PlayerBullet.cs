using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float expireTime;
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, expireTime);
    }

    void OnTriggerEnter2D(Collider2D hitInfo)               // wenn man die Methode auskommentiert, fliegt die kugel wieder oder man verschiebt im editor den bulletspawn wtf
    {
        if (!hitInfo.CompareTag("Player"))
        {
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }
}
