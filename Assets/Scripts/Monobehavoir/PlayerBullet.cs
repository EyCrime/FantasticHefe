using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 25;
    public Rigidbody2D rb;

    public Vector2 startPosition;
    public Vector2 endPosition;
    public float range;

    [SerializeField] private BulletType bullet;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition * range; 
    }

    void Update()
    {
        if (Vector2.Distance(startPosition, transform.position) > Vector2.Distance(startPosition, endPosition))
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)               // wenn man die Methode auskommentiert, fliegt die kugel wieder oder man verschiebt im editor den bulletspawn wtf
    {
        if (!hitInfo.CompareTag("Player") && !hitInfo.CompareTag("Turn"))
        {   
            Enemy enemy = hitInfo.GetComponent<Enemy>();
            if (enemy != null)
            {
                if ((bullet == BulletType.HotBullet && enemy.type == EnemyType.ColdEnemy) || (bullet == BulletType.ColdBullet && enemy.type == EnemyType.HotEnemy)) 
                {
                    enemy.TakeDamage(damage);
                    
                }

            }
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }
}

public enum BulletType
{
    HotBullet, ColdBullet
}
