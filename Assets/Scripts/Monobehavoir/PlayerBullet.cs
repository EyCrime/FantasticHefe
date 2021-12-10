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
        startPosition = transform.localPosition;
        endPosition = new Vector2(startPosition.x + range, startPosition.y);
    }

    void Update()
    {
        if (Vector2.Distance(startPosition, transform.localPosition) > Vector2.Distance(startPosition, endPosition))
        {
            DestroyBullet();
        }
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!hitInfo.CompareTag("Player") && !hitInfo.CompareTag("Turn") && !hitInfo.CompareTag("co2") && !hitInfo.CompareTag("hotWater") && !hitInfo.CompareTag("coldWater"))
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
