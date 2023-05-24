using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    public GameObject CheeseHead;
    public GameObject Projectile;

    float StartingPunchPosition;
    float EndingPunchPosition;
    int MaxPause;

    float PunchMotion;
    float AttackForce;
    float AttackPause;
    float Accumulator;

    bool Recoiling;

     void Start()
    {
        PunchMotion = Mathf.Infinity;
        AttackForce = 5;
        AttackPause = 1;
        Accumulator = 0.02f;
    }
    void Update()
    {
        GetComponentsInChildren<SpriteRenderer>()[1].enabled = (PLayerState.Instance.Attack == Attack.Projectile) ? true : false;
        if(Input.GetButtonDown("Punch") && PLayerState.Instance.Attack == Attack.Passive)
        {
            PLayerState.Instance.Attack = Attack.Punch;
            StartingPunchPosition = CheeseHead.transform.position.x;
            EndingPunchPosition = StartingPunchPosition + (int)PLayerState.Instance.DirectionFacing * 0.7f;

            MaxPause = 10;
            GetComponents<AudioSource>()[0].Play();
        }
        else if(Input.GetButtonDown("Projectile") && PLayerState.Instance.Attack == Attack.Passive && GameObject.Find("Projectile(Clone)") == null)
        {
            PLayerState.Instance.Attack = Attack.Projectile;
            StartingPunchPosition = CheeseHead.transform.position.x;
            EndingPunchPosition = StartingPunchPosition + (int)PLayerState.Instance.DirectionFacing * 0.5f;

            MaxPause =20;
            GetComponents<AudioSource>()[1].Play();
        }

        if(PLayerState.Instance.Attack == Attack.Punch || PLayerState.Instance.Attack == Attack.Projectile)
        {
            Accumulator += Time.deltaTime;

            if(PunchMotion == EndingPunchPosition)
            {
                AttackPause += Time.deltaTime * 60;
            }

            if(AttackPause > MaxPause)
            {
                if (PLayerState.Instance.Attack == Attack.Projectile)
                    GameObject.Instantiate(Projectile);
                {
                    AttackPause = 1;
                    Accumulator = 0.02f;
                    Recoiling = true;
                } 
            }

            if(!Recoiling)
            {
                PunchMotion = Mathf.Lerp(StartingPunchPosition, EndingPunchPosition, Accumulator * 7);
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(1, 1, 1), Accumulator * 5);
            }
            else
            {
                PunchMotion = Mathf.Lerp(EndingPunchPosition, StartingPunchPosition, Accumulator * 5);
                transform.localScale = Vector3.Lerp(transform.localScale, new Vector3(0.6f, 0.5f, 1f), Accumulator * 4);

                if(transform.position.x == StartingPunchPosition)
                {
                    Recoiling = false;
                    PLayerState.Instance.Attack = Attack.Passive;
                    Accumulator = 0.02f;
                }
            }

            transform.position = new Vector3(PunchMotion, CheeseHead.transform.position.y, transform.position.z);
            GetComponent<SpriteRenderer>().enabled = true;
        }
        else
        {
            GetComponent<SpriteRenderer>().enabled = false;
        } 
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            /*coll.gameObject.GetComponent<Rigidbody2D>().AddForce(
                new Vector2((float)PLayerState.Instance.DirectionFacing * AttackForce,AttackForce),
                ForceMode2D.Impulse);*/
            Rigidbody2D enemy =  coll.gameObject.GetComponent<Rigidbody2D>();
            enemy.velocity = new Vector2(0, 0);
            enemy.AddForce(new Vector2((float)PLayerState.Instance.DirectionFacing * AttackForce, AttackForce), ForceMode2D.Impulse);

            enemy.GetComponent<Enemy>().DoDamage(2);
            WorldManager.Score += 200;
        }
    }
}
