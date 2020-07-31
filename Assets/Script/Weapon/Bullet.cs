using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public float speed = 30f;
    public int damage = 5;
   
    public Rigidbody2D rdg2;

    // Start is called before the first frame update
    void Start()
    {
        /*StartCoroutine(Die());*/
        rdg2.velocity = transform.right * speed;
    }


    /*IEnumerator Die()
    {
     //play your sound
     //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(2);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
    
        Destroy(gameObject); //this will work after 3 seconds.
    }
    
    /*void Update()
    {
        Destroy(gameObject, 2);
    }*/
    

    void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Enemy enemy = hitInfo.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }
        Destroy(gameObject);
    }

   
}
