using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    int Direction;
    int Speed;
    float Timer;
    void Start()
    {
        Direction = (int)PLayerState.Instance.DirectionFacing;
        transform.position = GameObject.Find("Fist").transform.position - new Vector3(0.3f, 0, 0) * Direction;
        Speed = 12;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x + Time.deltaTime * Speed * Direction, transform.position.y);
        transform.Rotate(0, 0, 6 * Direction * -1 * Time.deltaTime * 60);
        Timer += Time.deltaTime * 60;

        if(Timer > 120)
        {
            GameObject.Destroy(gameObject);
        }
    }

     void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(gameObject);

            Rigidbody2D enemy =  coll.gameObject.GetComponent<Rigidbody2D>();
            enemy.velocity = new Vector2(0, 0);

            enemy.AddForce(new Vector2((float)PLayerState.Instance.DirectionFacing * 11, 14), ForceMode2D.Impulse);
            enemy.GetComponent<Enemy>().DoDamage(1);

            WorldManager.Score += 125;
           // coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Direction * 11, 14), ForceMode2D.Impulse);
        }
    }
}
