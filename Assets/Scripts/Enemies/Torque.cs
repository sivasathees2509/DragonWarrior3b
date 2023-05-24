using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torque : Enemy
{
    
    void Start()
    {
        HP = 2;
        Collider.radius = 0.19f; 
    }

    void FixedUpdate()
    {
        MovementPattern();
        BorderHitCheck(80);
        DestroyOutofBounds();
    }

    protected override void MovementPattern()
    {
        if(Body.velocity.y < 0)
        {
            Body.AddTorque((float)Speed / 2 * Direction);
        }
        else if(Body.velocity.y == 0)
        {
            Body.AddForce(new Vector2(0, 100));
        }
    }


}
