using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet1 : PathFollower
{
    public float speed = 20f;
    public Rigidbody rb;
    //public float speeding;
    

    // Start is called before the first frame update
    void Start()
    {
        rb.velocity = transform.forward * speed;
        Destroy(gameObject, 10.0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        
        Destroy(gameObject);
        if(collision.gameObject.tag == "Enemy")
        {

            //speeding = PathFollower._speed = new float();
            Destroy(gameObject);
        }
    }

}
