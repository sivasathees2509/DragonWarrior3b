using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DarkenCycle : MonoBehaviour
{
    SpriteRenderer Renderer;
    float minBrightness;
    float maxBrightness;
    float cycleSpeed;
    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        minBrightness = 0.08f;
        maxBrightness = 1.0f;
        cycleSpeed = 0.05f;
    }

    // Update is called once per frame
    void Update()
    {
       Renderer.color =  Color.Lerp(new Color(maxBrightness, maxBrightness, maxBrightness, 1),
                   new Color(minBrightness, minBrightness, minBrightness, 1),
                   Mathf.PingPong(Time.time * cycleSpeed, maxBrightness));
    }
}
