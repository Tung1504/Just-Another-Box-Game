using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{

    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rdg2;

    // Start is called before the first frame update
    void Start()
    {
        rdg2.velocity = transform.right * speed;
    }

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        //Destroy(gameObject);
    }

   
}
