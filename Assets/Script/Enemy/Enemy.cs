using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rgd2;
    public int maxHealth = 100;
    public float speed = 10f;
    public bool isGround;
    public Transform groundCheck;
    public float checkRadius = 0.5f;
    public LayerMask groundLayer;
    private bool movingRight = false;
    
    public void TakeDamage(int damage)
    {
        maxHealth -= damage;
       
        
        if (maxHealth <= 0)
        {
            Die();
        }
    }

    void Start()
    {
        rgd2 = GetComponent<Rigidbody2D>(); 
    }
    void Update()
    {
        isGround = Physics2D.OverlapCircle(groundCheck.position, checkRadius, groundLayer);
        rgd2.velocity = new Vector2(speed, rgd2.velocity.y);
        if (isGround)
        {
            movingRight = true;
            transform.eulerAngles = new Vector3(0,0,0);
        }
        else
        {
            movingRight = false;
        }
    }
    void Die()
    {
        Destroy(gameObject);
    }
}
