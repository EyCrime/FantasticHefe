using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : MonoBehaviour
{
    // Start is called before the first frame update
    public CharacterController2D controller;

    public float runSpeed = 40f;

    float horizontalMove = 0f;

    bool jump = false;

    bool crouch = false;

    bool fly=false;

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;
    
        if(Input.GetButtonDown("Jump"))
        {
            jump=true;
            fly=true;
        }
        else if(Input.GetButtonUp("Jump"))
        {
            fly=false;
        }
    
        if(Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        }
        else if(Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }
    }

    void FixedUpdate()
    {      
        //move character
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch,jump,fly);
        jump=false;
    }
}
