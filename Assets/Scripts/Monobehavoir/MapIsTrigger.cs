using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIsTrigger : MonoBehaviour
{
    public GameObject player;
    private CompositeCollider2D plattformCollider;
    public BoxCollider2D playerCollider;
    private bool twice;

    private void Start()
    {
        plattformCollider = gameObject.GetComponent<CompositeCollider2D>();
        playerCollider = player.GetComponent<BoxCollider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision == playerCollider)
        {
            plattformCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && collision == playerCollider)
        {
                plattformCollider.isTrigger = false;
        }

    }
}
