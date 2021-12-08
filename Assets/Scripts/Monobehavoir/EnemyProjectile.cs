using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public int damage = 25;
    public float range;
    public Vector2 startPosition;
    public Vector2 endPosition;

    public Rigidbody2D rb;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position;
        endPosition = startPosition * range;

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);
            rb.AddForce((target - startPosition).normalized * speed, ForceMode2D.Impulse);
        }
    }

    // Update is called once per frame
    void Update()
    {     
        if (player != null)
        {
            if (Vector2.Distance(startPosition, transform.position) > Vector2.Distance(startPosition, endPosition))
            {
                DestroyProjectile();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (!hitInfo.CompareTag("Enemy") && !hitInfo.CompareTag("Turn"))
        {
            if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("PlayerBullet"))
            {
                Player player = hitInfo.GetComponent<Player>();
                if (player != null && hitInfo.isTrigger)
                {
                    player.TakeDamage(damage);
                }
                DestroyProjectile();
            }
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
