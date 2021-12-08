using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieWhenFall : MonoBehaviour
{
    public int damage = 25;
    [SerializeField] private GameObject p;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            print("testetst");

            Player player = other.GetComponent<Player>();
            if (player != null && other.isTrigger)
            {
                player.TakeDamage(damage);
            }

            Destroy(p);
            RespawnManager.instance.Respawn();


        }
    }
}
