using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D CheesyBody;
    float HorizontalMotion;
    bool jumpActivated;

    public static int MoveSpeed;
    public static bool IsSpooked;
    float SpookTimer;

    void Start()
    {
        HorizontalMotion = 0;
        MoveSpeed = 3;
        CheesyBody = GetComponent<Rigidbody2D>();
        PLayerState.Instance.Horizontal = Horizontal.Idle;
        PLayerState.Instance.Vertical = Vertical.Airborne;
        PLayerState.Instance.DirectionFacing = DirectionFacing.Right;
        PLayerState.Instance.Attack = Attack.Passive;
        
    }

    private void FixedUpdate()
    {
        WalkMotion();

        JumpMotion();
    }
    // Update is called once per frame
    void Update()
    {
        SpookedCheck();
        if(PLayerState.Instance.Attack != Attack.Passive)
        {
            CheesyBody.velocity = new Vector2(0, 0.1f);
            HorizontalMotion = 0;
        }
        else
        {
            HorizontalMotion = Input.GetAxisRaw("Horizontal");

            if (HorizontalMotion != 0)
            {
                transform.localScale = new Vector3(HorizontalMotion, 1, 1);
                PLayerState.Instance.DirectionFacing = (DirectionFacing)HorizontalMotion;
            }

            if (Input.GetButtonDown("Jump"))
            {
                jumpActivated = true;
            } 

        }
        
        if(CheesyBody.velocity.y == 0 && PLayerState.Instance.Attack == Attack.Passive)
        {
            PLayerState.Instance.Vertical = Vertical.Grounded;
        }

        Horizontal previousMotion = PLayerState.Instance.Horizontal;
        Horizontal currentMotion = PLayerState.Instance.Horizontal = (Horizontal)HorizontalMotion;

        if((int)previousMotion * (int)currentMotion == -1)
        {
            PLayerState.Instance.Horizontal = Horizontal.Idle;
        }

    }

    private void WalkMotion()
    {
        CheesyBody.velocity = new Vector2(HorizontalMotion * MoveSpeed, CheesyBody.velocity.y);
    }

    private void JumpMotion()
    {
        if (jumpActivated)
        {
            if (PLayerState.Instance.Vertical == Vertical.Grounded)
            {
                PLayerState.Instance.Vertical = Vertical.Airborne;
                CheesyBody.AddForce(new Vector2(CheesyBody.velocity.x, 6), ForceMode2D.Impulse);
                GetComponent<AudioSource>().Play();
            }

            jumpActivated = false;
        }
    }

    private void SpookedCheck()
    {
        int lerpTo;
        float lerpSpeed;

        if(IsSpooked)
        {
            SpookTimer += Time.deltaTime * 60;
            lerpTo = 0;
            lerpSpeed = 0.6f;
        }
        else
        {
            lerpTo = 1;
            lerpSpeed = 0.8f;
        }
        SpriteRenderer[] renderers = GetComponentsInChildren<SpriteRenderer>();
        foreach(SpriteRenderer renderer in renderers)
        {
            renderer.color = Color.Lerp(renderer.color, new Color(lerpTo, 1, 1, 1), lerpSpeed * Time.deltaTime);
        }
        if(SpookTimer > 180)
        {
            SpookTimer = 0;
            MoveSpeed = 3;
            IsSpooked = false;
        }
    }
}
