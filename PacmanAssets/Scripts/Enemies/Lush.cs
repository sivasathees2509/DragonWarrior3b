using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lush : Enemy
{
    public float Timer;
    public int HorizontalMotion;
    int MaxWobbleWidth;

    void Start()
    {
        HP = 1;
        Collider.radius = 0.20f;
        Sprite.material.color = new Color(0.8f, 1, 1);
        transform.localScale = new Vector3(1.4f, 1.4f, 1);

        MaxWobbleWidth = 2000 / Speed;

        if(Camera.main.WorldToViewportPoint(transform.position).x > 0.5f)
        {
            Direction = -1;
        }
        else
        {
            Direction = 1;
        }
    }

    void Update()
    {
        if(Timer < MaxWobbleWidth / 2)
        {
            HorizontalMotion = 1 * Direction;
        }
        else if(Timer < MaxWobbleWidth)
        {
            HorizontalMotion = -1 * Direction;
        }
        else if(Timer >  MaxWobbleWidth)
        {
            Timer = 0;
        }

        Timer += Time.deltaTime * 60; 
    }

    void FixedUpdate()
    {
        MovementPattern();
        BorderHitCheck(20);
        DestroyOutofBounds();
    }

    protected override void MovementPattern()
    {
        Body.AddForce(new Vector2(HorizontalMotion * Speed, Body.velocity.y), ForceMode2D.Force);

        //Cap Inertial Motion Speed
        if(Body.velocity.x < Speed / 2 * -1)
        {
            Body.velocity = new Vector2(Speed / 2 * -1, Body.velocity.y);
        }
        if (Body.velocity.x > Speed / 2)
        {
            Body.velocity = new Vector2(Speed / 2, Body.velocity.y);
        }
    }

}
