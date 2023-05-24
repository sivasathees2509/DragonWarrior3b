using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldManager : MonoBehaviour
{
    public static int Score;

    public static int Level;
    private static int _difficulty;
    public static int Difficulty 
    {
        get
        {
            return Level / 3;
        }
    }

    private bool PauseSwitch;

    void Awake()
    {
        Level = 3;
    }

    void Start()
    {
        Application.targetFrameRate = 60;
        QualitySettings.vSyncCount = 0; // Set Vsync to 1  for build  to avoid jitter, set  to 0 in editor  for debugging different FPS
    }

    void Update()
    {
        GamePause();
    }

    private void GamePause()
    {
        if(Input.GetButtonDown("Start"))
        {
            PauseSwitch = !PauseSwitch;
        }

        if(PauseSwitch && !GameOverManager.IsGameOver)
        {
            Time.timeScale = 0;
            GameObject.Find("CheeseHead").GetComponent<PlayerController>().enabled = false;
        }

        else if(!PauseSwitch && !GameOverManager.IsGameOver)
        {
            Time.timeScale = 1;
            GameObject.Find("CheeseHead").GetComponent<PlayerController>().enabled = true;
        }
    }
}
