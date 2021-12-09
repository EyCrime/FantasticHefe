using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIsTrigger : MonoBehaviour
{
    public GameObject player;
    private CompositeCollider2D plattformCollider;
    private BoxCollider2D playerCollider;
    private CircleCollider2D CplayerCollider;
    private bool twice;

    private void Start()
    {
        plattformCollider = gameObject.GetComponent<CompositeCollider2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
        CplayerCollider = player.GetComponent<CircleCollider2D>();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.CompareTag("Player") && !playerCollider.isTrigger)
        {
            plattformCollider.isTrigger = true;
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !playerCollider.isTrigger)
        {
            if (twice)
            {
                plattformCollider.isTrigger = false;
            }

            twice = !twice;
        }

    }
}
