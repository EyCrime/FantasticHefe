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
    ParticleSystem ps;
    public bool directionRight;

    // Start is called before the first frame update
    private void Awake()
    {
        ps=GetComponentInChildren<ParticleSystem>();
    }
    private void Start()
    {
       if(Throw)
       {    
        ps.Play();
        Destroy(gameObject, 5);//5 seconds boom!!!
       }
       
       
       if(gameObject==null)
       {
           ps.Stop();
       }
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
                }
            }
        }
        else{
        var enemy = collision.collider.GetComponent<Enemy>();
        if(enemy)
        {
            enemy.Die();
        }
        Destroy(gameObject);
        }
        }
       
}
