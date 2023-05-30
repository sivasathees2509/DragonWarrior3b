using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTest : MonoBehaviour
{

    private Rigidbody2D rb;
    private void FixedUpdate()
    {
        rb = GetComponent<Rigidbody2D>();
        //rb = GetComponent<Rigidbody2D>();
        //Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(1, rb.velocity.y);

        if(rb.velocity.y == 0)
        {
            rb.AddForce(new Vector2(0, 300));
        }
    }
}
