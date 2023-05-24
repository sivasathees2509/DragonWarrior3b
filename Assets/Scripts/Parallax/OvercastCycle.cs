using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvercastCycle : MonoBehaviour
{
    SpriteRenderer Renderer;
    float minOpacity;
    float maxOpaciy;
    float cycleSpeed;

    void Start()
    {
        Renderer = GetComponent<SpriteRenderer>();
        minOpacity = 0.6f;
        maxOpaciy = 1.0f;
        cycleSpeed = 0.05f; 
    }

    // Update is called once per frame
    void Update()
    {
        Renderer.color = Color.Lerp(new Color(1,1,1, maxOpaciy),
            new Color(1,1,1, minOpacity), 
            Mathf.PingPong(Time.time * cycleSpeed, maxOpaciy));
    }
}
