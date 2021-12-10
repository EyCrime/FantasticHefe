using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetDownOnPlattform : MonoBehaviour
{

    //originally meant to create one way plattforms via is Trigger until we discovered the Effector and that we had to remove the composit collider for this 
    //hence the name 
    //now for getting down on plattforms 

    private GameObject currentPlattform;
    public CircleCollider2D CplayerCollider;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (currentPlattform != null)
            {
                StartCoroutine(DisableCollision());
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plattform"))
        {
            currentPlattform = collision.gameObject;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plattform"))
        {
            currentPlattform = null;
        }
    }

    private IEnumerator DisableCollision()
    {
        BoxCollider2D platformCollider = currentPlattform.GetComponent<BoxCollider2D>();

        Physics2D.IgnoreCollision(CplayerCollider, platformCollider);
        yield return new WaitForSeconds(0.25f);
        Physics2D.IgnoreCollision(CplayerCollider, platformCollider, false);
    }

}
