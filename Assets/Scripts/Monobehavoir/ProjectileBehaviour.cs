using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehaviour : MonoBehaviour
{
    public float Speed = 4;
    public Vector3 LaunchOffset;
    public bool Throw;

    // Start is called before the first frame update
    void Start()
    {
       if(Throw)
       {
           var direction = -transform.right + Vector3.up;
           GetComponent<Rigidbody2D>().AddForce(direction * Speed, ForceMode2D.Impulse);
       } 
       transform.Translate(LaunchOffset);
       Destroy(gameObject, 5);//5 seconds boom!!!
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
