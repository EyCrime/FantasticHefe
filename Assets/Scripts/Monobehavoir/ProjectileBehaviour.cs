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
           GetComponent<RigidBody2D>()
       } 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
