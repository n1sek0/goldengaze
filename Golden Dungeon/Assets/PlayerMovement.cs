using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    private float horizontalMove = 0f;
    public float runSpeed = 40f;
    private bool jump = false;

    void Start()
    {
        // Assign the CharacterController2D component to the controller variable
        controller = GetComponent<CharacterController2D>();
    }

    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(horizontalMove));
        
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping",true);
        }
    }

    public void OnLanding()
    {
        animator.SetBool("IsJumping", false);
    }

    private void FixedUpdate()
    {
        controller.Move(horizontalMove * Time.fixedDeltaTime, false, jump);
        jump = false;
    }
}


