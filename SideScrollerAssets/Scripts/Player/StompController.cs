using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StompController : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Enemy")
        {
            GameObject.Destroy(coll.gameObject);

            Rigidbody2D cheeseHead = GameObject.Find("CheeseHead").GetComponent<Rigidbody2D>();
            cheeseHead.velocity = new Vector2(cheeseHead.velocity.x, 0);
            cheeseHead.AddForce(new Vector2(0, 5), ForceMode2D.Impulse);

            //GetComponentInParent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            GetComponent<AudioSource>().Play();

            WorldManager.Score += 300;
        }
    }
}
