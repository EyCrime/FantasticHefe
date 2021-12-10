using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapIsTrigger : MonoBehaviour
{
    public GameObject player;
    private CompositeCollider2D plattformCollider;

    public BoxCollider2D playerCollider;
    public CircleCollider2D CplayerCollider;

    private bool twice;

    private void Start()
    {
        plattformCollider = gameObject.GetComponent<CompositeCollider2D>();;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            plattformCollider.isTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !collision.isTrigger && collision.Equals(CplayerCollider))
        {
                plattformCollider.isTrigger = false;
        }

    }
}
