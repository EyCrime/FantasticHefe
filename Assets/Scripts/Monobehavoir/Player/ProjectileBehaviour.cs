using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehaviour : MonoBehaviour
{
    public float splashRange = 2;
    public float speed = 7;
    public float explodeTime = 3.0f;
    public float destroyTime = .5f;
    private AudioSource bombSound;
    private ParticleSystem ps;
    private SpriteRenderer sprite;
    private Rigidbody2D rb;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
        bombSound = GetComponent<AudioSource>();
        StartCoroutine(ExplodeBombCor());
    }

    private void OnCollisionEnter2D(Collision2D other) 
    {
        if(other.collider.CompareTag("Enemy"))
        {
            Explode();
        }
    }

    private IEnumerator ExplodeBombCor()
    {
        yield return new WaitForSeconds(explodeTime);
        Explode();
    } 

    private void Explode() {
        ps.Play();
        rb.velocity = Vector2.zero;
        bombSound.Play();
        sprite.enabled = false;

        var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
        foreach(var hitCollider in hitColliders)
        {
            if(hitCollider.CompareTag("Enemy"))
                hitCollider.GetComponent<Enemy>().Die();
        }

        Destroy(gameObject, destroyTime);
    }
}
