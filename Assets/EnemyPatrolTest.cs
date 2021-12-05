using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrolTest : MonoBehaviour
{
    public bool mustPatrol;
    private bool mustTurn;

    public float walkSpeed;

    public Rigidbody2D rb;

    public Transform groundCheckPos;
    public LayerMask groundLayer;

    void Start()
    {
        mustPatrol = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (mustPatrol == true)
        {
            Patrol();
        }
    }

    private void FixedUpdate()
    {
        if (mustPatrol == true)
        {
            mustTurn = !Physics2D.OverlapCircle(groundCheckPos.position, 0.1f, groundLayer);
        }
    }

    void Patrol()
    {
        rb.velocity = new Vector2(walkSpeed * Time.deltaTime, rb.velocity.y);
        if (mustTurn == true)
        {
            Flip();
        }
    }

    void Flip()
    {
        transform.localScale = new Vector2(transform.localScale.x * -1, transform.localScale.y);
        walkSpeed *= -1;
        mustTurn = false;
    }
}
