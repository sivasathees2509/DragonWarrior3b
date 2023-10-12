using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipBullet : MonoBehaviour
{
    private Rigidbody2D rb;

    public float speed = 2f;

    public GameObject fireball;

    public float invokeFloatTime = 0.01f;
    public float invokeFloatRepeatRate = 0.5f;

    private bool fireballActive;

    public Transform spawnpoint;




    public float fireballRate = 5f;

    void Awake()
    {
        rb = this.GetComponent<Rigidbody2D>();

    }

   
    void Update()
    {
        rb.velocity = new Vector2(-speed, 0);

        if (!fireballActive)
        {

            InvokeRepeating("FireballAttack", invokeFloatTime, invokeFloatRepeatRate);
        }


    }


    private void FireballAttack()
    {
        Instantiate(fireball, spawnpoint.position, Quaternion.identity);

        // fireBall.destroyed += FireballDestroyed;
        fireballActive = true;

    }

    private void FireballDestroyed()
    {
        fireballActive = false;
    }



}
