using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bouncer : Enemy
{
    void Start()
    {
        HP = 1;
        Collider.radius = 0.19f;
        transform.localScale = new Vector3(1.2f, 1.2f, 1.0f);
    }

    void FixedUpdate()
    {
        MovementPattern();
        BorderHitCheck(50);
        DestroyOutofBounds();

    }

    protected override void MovementPattern()
    {
        Body.velocity = new Vector2(1 * Direction, Body.velocity.y);

        if (Body.velocity.y == 0)
        {
            Body.AddForce(new Vector2(0, 300));
        }
    }
}
