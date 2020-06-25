using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rgd2;
    private Animator anim;
    
    public float speed;
    private float moveInput;    

    public Collider2D colliderDisable;
    public Transform cellingCheck;
    public bool isTouchingCelling;
    
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask groundLayer;
    
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

    }
}
