using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    public float speed;
    public int damage = 25;

    private Transform player;
    private Vector2 target;

    // Start is called before the first frame update
    void Start()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;
            target = new Vector2(player.position.x, player.position.y);
        }      
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, speed * Time.deltaTime);

            if (transform.position.x == target.x && transform.position.y == target.y)
            {
                DestroyProjectile();
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        if (hitInfo.CompareTag("Player") || hitInfo.CompareTag("Projectile"))
        {
            DestroyProjectile();
        }

        if (!hitInfo.CompareTag("Enemy"))
        {

            Player player = hitInfo.GetComponent<Player>();
            if (player != null && hitInfo.isTrigger)
            {
                player.TakeDamage(damage);
            }
            Destroy(gameObject);
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
