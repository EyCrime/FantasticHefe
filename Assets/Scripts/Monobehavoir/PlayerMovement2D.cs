using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;
    public Animator animator;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool fly=false;
    ParticleSystem ps;

    // Update is called once per frame
   void Awake()
   {
       ps=GetComponentInChildren<ParticleSystem>();
   }
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump=true;
            fly=true;
            ps.Play();
            animator.SetBool("isJumping", true);
        }
        else if(Input.GetButtonUp("Jump"))
        {
            fly=false;
            ps.Stop();
        }
    }

    void FixedUpdate()
    {      
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, jump,fly);
        jump=false;
        animator.SetBool("isJumping", false);
    }
}
