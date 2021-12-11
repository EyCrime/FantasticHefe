using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehaviour : MonoBehaviour
{
    public float splashRange = 1;
    public float speed = 7;
    public float explodeTime = 3.0f;
    public float destroyTime = .5f;
    private AudioSource bombSound;
    private ParticleSystem ps;
    private Rigidbody2D rb;

    private void Start()
    {
        ps = GetComponentInChildren<ParticleSystem>();
        rb = GetComponent<Rigidbody2D>();
        bombSound = GetComponent<AudioSource>();
        StartCoroutine(DestroyBombCor());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(splashRange>0)
        {
           var hitColliders = Physics2D.OverlapCircleAll(transform.position, splashRange);
            foreach(var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Enemy>();
                if(enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(splashRange, 0, distance);
                    enemy.Die();
                    DestroyBomb();
                }
               
            }
        }
        else
        {
            var enemy = collision.collider.GetComponent<Enemy>();
            if(enemy)
                enemy.Die();
        }
    }

    private IEnumerator DestroyBombCor()
    {
        yield return new WaitForSeconds(explodeTime);
        DestroyBomb();
    } 

    private void DestroyBomb() {
        ps.Play();
        rb.velocity = Vector2.zero;
        bombSound.Play();
        Destroy(gameObject, destroyTime);
    }
}
