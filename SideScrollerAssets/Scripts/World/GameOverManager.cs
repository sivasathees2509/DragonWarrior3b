using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    SpriteRenderer GameOverRenderer;
    public static bool IsGameOver;

    void Start()
    {
        GameOverRenderer = GetComponent<SpriteRenderer>();
        IsGameOver = false;
    }

    void Update()
    {
        if (IsGameOver)
        {
            GameOverRenderer.color = Color.Lerp(GameOverRenderer.color, new Color(1, 1, 1, 0.8f), 0.5f * Time.deltaTime);

            GameStartManager reStart = GetComponentInChildren<GameStartManager>();
            reStart.enabled = true;
        }
    }
} 
