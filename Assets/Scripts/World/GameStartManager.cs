using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStartManager : MonoBehaviour
{
    float LoopTimer;

    void Update()
    {
        LoopTimer += Time.deltaTime * 60;
        
        if(LoopTimer > 30 )
        {
            SpriteRenderer pressEnterRenderer = GetComponent<SpriteRenderer>();
            pressEnterRenderer.enabled = !pressEnterRenderer.enabled;
            LoopTimer = 0;
        }

        if(Input.GetButtonDown("Start"))
        {
            WorldManager.Score = 0;
            Application.LoadLevel("MainScene");
        }
    }
}
