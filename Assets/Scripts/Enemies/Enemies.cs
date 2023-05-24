using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy<T> where T : Enemy
{
    public GameObject GameObject;
    public T ScriptComponent;

    public Enemy(string name)
    {
        GameObject = new GameObject(name);
        ScriptComponent = GameObject.AddComponent<T>();
    }
}

public abstract class Enemy : MonoBehaviour
{
    protected int HP;

    public Rigidbody2D Body;
    public SpriteRenderer Sprite;
    public CircleCollider2D Collider;

    public int Speed;
    public int Direction;

    protected abstract void MovementPattern();

    void Awake()
    {
        // Add common components
        Body = gameObject.AddComponent<Rigidbody2D>();
        Sprite = gameObject.AddComponent<SpriteRenderer>();
        Collider = gameObject.AddComponent<CircleCollider2D>();

        //Set commom sprite
        Sprite.sprite = Resources.Load<Sprite>("EyeBall");
        Body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

        gameObject.tag = "Enemy";
        gameObject.layer = LayerMask.NameToLayer("EyeBall");
    }

    // Insert all unique values  to be determined at instantiation here

    public  void initialize(int speed, int direction, Vector3 poition)
    {
        Speed = speed;
        Direction = direction;
        transform.position = poition;
    }

    public void initialize(int speed, Vector3 poition)
    {
        Speed = speed;
        transform.position = poition;
    }

    public void DoDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP <= 0)
        {
            GameObject.Find("Stomper").GetComponent<AudioSource>().Play();
            Destroy(gameObject);
        }
    }

    protected void BorderHitCheck(float force)
    {
        force *= Speed;
        Vector3 enemyPosition = Camera.main.WorldToViewportPoint(transform.position);

        if(enemyPosition.x < 0f)
        {
            Body.velocity = new Vector2(0, Body.velocity.y);
            Body.AddForce(new Vector2(force, 0));
            Direction = 1;
        }
        else if(enemyPosition.x > 1f)
        {
            Body.velocity = new Vector2(0, Body.velocity.y);
            Body.AddForce(new Vector2(force * -1, 0));
            Direction = -1;
        }
    }

    protected void DestroyOutofBounds()
    {
        if(transform.position.y < -6 || transform.position.y > 20)
        {
            GameObject.Destroy(gameObject);
        }
    }

    protected virtual void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            Rigidbody2D CheeseBody = coll.gameObject.GetComponent<Rigidbody2D>();
            CheeseBody.velocity = new Vector2(0, 0);
            CheeseBody.AddForce(new Vector2(0, 300));

            coll.gameObject.GetComponent<PlayerController>().enabled = false;
            //coll.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 300));

            coll.gameObject.GetComponent<Collider2D>().enabled = false;

            foreach (Transform child in coll.gameObject.transform)
            {
                Destroy(child.gameObject);
            }

            GameOverManager.IsGameOver = true;
        }      
    }
}





