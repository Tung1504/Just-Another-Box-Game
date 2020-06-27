﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rgd2;
    private Animator anim;
    
    // Events
    
    
    // Running
    public float speed;
    private float moveInput;
    public float crunchSpeed;

    // Celling Check
    public Collider2D colliderDisable;
    public Transform cellingCheck;
    public bool isTouchingCelling;
    
    // Ground Check
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;

    //Jump
    public float jumpForce;
    
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rgd2 = GetComponent<Rigidbody2D>();  
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        isTouchingCelling = Physics2D.OverlapCircle(cellingCheck.position, checkRadius, groundLayer);
        
        moveInput = Input.GetAxis("Horizontal");
        rgd2.velocity = new Vector2(moveInput * speed, rgd2.velocity.y);
        if(moveInput < 0)
        {
            transform.eulerAngles = new Vector3(0,180,0);
        }
        else if (moveInput > 0)
        {
            transform.eulerAngles = new Vector3(0,0,0);
        }


        if (moveInput != 0 && isGround)
        {
            anim.SetBool("isRunning", true);
        }
        else if (moveInput == 0 && isGround)
        {
            anim.SetBool("isRunning", false);
        }

        


        if (Input.GetKey("down") && isGround  || isGround && isTouchingCelling)
        {
            rgd2.velocity = new Vector2(moveInput * crunchSpeed, rgd2.velocity.y);
            anim.SetBool("isCrouching", true);
            colliderDisable.enabled = false;
        }
        else
        {
            anim.SetBool("isCrouching", false);
            colliderDisable.enabled = true;
        }


        if (Input.GetKeyDown("a") && isGround )
        {
            anim.SetBool("isShooting", true);
        }
        else if (Input.GetKeyUp("a") && isGround )
        {
            anim.SetBool("isShooting", false);
        }

        
        if (Input.GetKeyDown("z") && isGround)
        {
            rgd2.velocity = Vector2.up * jumpForce;
            anim.SetBool("isJump", true);
        }
        else
        {
            anim.SetBool("isJump", false);
        }

        if(rgd2.velocity.y < -0.1 && !isGround)
        {
            anim.SetBool("isFalling", true);
        }
        else
        {
            anim.SetBool("isFalling", false);
        }
        
    }
    
    
    
}
