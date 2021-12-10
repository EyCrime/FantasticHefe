using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileBehaviour : MonoBehaviour
{
    
    public float Speed = 7;
    public Vector3 LaunchOffset;
    public bool Throw;
    public float Damage =1;
    public float SplashRange = 1;
    public ParticleSystem ps;
    public bool directionRight;
    public float explodeTime=3.0f;
    public float destroyTime=.5f;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    private void Awake()
    {
        ps=GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
       StartCoroutine(DestroyBomb());
       
    }

    // Update is called once per frame
    public void Update()
    {
       if(!Throw)
       {
           transform.position += -transform.right * Speed * Time.deltaTime;
       } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(SplashRange>0)
        {
           var hitColliders = Physics2D.OverlapCircleAll(transform.position, SplashRange);
            foreach(var hitCollider in hitColliders)
            {
                var enemy = hitCollider.GetComponent<Enemy>();
                if(enemy)
                {
                    var closestPoint = hitCollider.ClosestPoint(transform.position);
                    var distance = Vector3.Distance(closestPoint, transform.position);

                    var damagePercent = Mathf.InverseLerp(SplashRange,0,distance);
                    enemy.Die();
                    ps.Play();
                    rb.velocity = Vector2.zero;
                     Destroy(gameObject, destroyTime);
                }
               
            }
        }
        else{
        var enemy = collision.collider.GetComponent<Enemy>();
        if(enemy)
        {   
            enemy.Die();
        }
        
        }
        }
    private IEnumerator DestroyBomb()
    {
        yield return new WaitForSeconds(explodeTime);
        ps.Play();
        rb.velocity = Vector2.zero;
        Destroy(gameObject, destroyTime);
    } 
}
