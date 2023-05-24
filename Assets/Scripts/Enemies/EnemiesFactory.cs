using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesFactory : MonoBehaviour
{
    void Awake()
    {
        BoxCollider2D collider = gameObject.AddComponent<BoxCollider2D>();
        collider.isTrigger = true;
        collider.offset = new Vector2(0, 5);
        collider.size = new Vector2(0.5f, 9.5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(GetComponent<BoxCollider2D>());
            WorldManager.Level++;

            for(int i = 0; i < WorldManager.Difficulty; i++)
            {
                int randomInstance = Random.Range(0, 6);
                float randomX = transform.position.x + (6 * (Random.Range(0, 2) * 2 - 1));
                float randomY = Random.Range(4, 8);

                switch (randomInstance)
                {
                    case 0:
                        // Gigantor
                        Enemy<Gigantor> giantGeorge = new Enemy<Gigantor>("GiantGeorge");
                        giantGeorge.ScriptComponent.initialize(speed: 1, poition: new Vector3(randomX, randomY, 1));
                        break;

                    case 1:
                        //Tweaker
                        Enemy<Tweaker> tweakyTim = new Enemy<Tweaker>("TweakyTim");
                        tweakyTim.ScriptComponent.initialize(speed: 4, poition: new Vector3(randomX, randomY, 1));
                        break;

                    case 2:
                        //Lush
                        Enemy<Lush> lushyLinda = new Enemy<Lush>("LushyLinda");
                        lushyLinda.ScriptComponent.initialize(speed: Random.Range(6, 18), poition: new Vector3(randomX, randomY, 1));
                        break;

                    case 3:
                        //Bouncer
                        Enemy<Bouncer> bouncyBill = new Enemy<Bouncer>("BouncyBill");
                        bouncyBill.ScriptComponent.initialize(
                            speed: 4,
                            direction: Random.Range(0, 2) * 2 - 1,
                            poition: new Vector3(randomX, randomY, 1)
                            );
                        break;

                    case 4:
                        //Torque
                        Enemy<Torque> torqyTom = new Enemy<Torque>("TorqyTom");
                        torqyTom.ScriptComponent.initialize(speed: 3, direction: Random.Range(0, 2) * 2 - 1, poition: new Vector3(randomX, randomY, 1));
                        break;

                    case 5:
                        //Ghost
                        Enemy<Ghost> ghostlyGayle = new Enemy<Ghost>("GhostlyGayle");
                        ghostlyGayle.ScriptComponent.initialize(speed: 2, poition: new Vector3(randomX, randomY, 1));
                        break;

                }
            }
        }


    }
}
    
    /*void Temp()
    {
        /* Enemy<Bouncer> bouncyBill = new Enemy<Bouncer>("BouncyBill");
         bouncyBill.ScriptComponent.initialize(
             speed: 4, 
             direction: Random.Range(0, 2) * 2 - 1, 
             poition: new Vector3(1, 1, 1)
             );*/

        /*Enemy<Gigantor> giantGeorge = new Enemy<Gigantor>("GiantGeorge");
        giantGeorge.ScriptComponent.initialize(speed: 1, poition: new Vector3 (1, 1, 1));*/

        /*Enemy<Ghost> ghostlyGayle = new Enemy<Ghost>("GhostlyGayle");
        ghostlyGayle.ScriptComponent.initialize(speed: 2, poition: new Vector3(1, 1, 1));*/

        /*Enemy<Lush> lushyLinda = new Enemy<Lush>("LushyLinda");
        lushyLinda.ScriptComponent.initialize(speed: Random.Range(6, 18), poition: new Vector3(1, 1, 1));*/

        /*Enemy<Torque> torqyTom = new Enemy<Torque>("TorqyTom");
        torqyTom.ScriptComponent.initialize(speed: 3, direction: Random.Range(0, 2) * 2 -1, poition: new Vector3(1, 1, 1));*/

        /*Enemy<Tweaker> tweakyTim = new Enemy<Tweaker>("TweakyTim");
        tweakyTim.ScriptComponent.initialize(speed: 4, poition: new Vector3(1, 1, 1));
    }*/

