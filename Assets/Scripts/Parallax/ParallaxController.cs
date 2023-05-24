using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    public float Speed;
    public float AutoScroll;
    Camera MainCamera;
    Vector3 ParallaxFollowCamera;
    private float Scroll;
    private float OffSet;
    void Start()
    {
        MainCamera = Camera.main;
        ParallaxFollowCamera = transform.position;
        OffSet = transform.position.x;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Scroll += AutoScroll;
        ParallaxFollowCamera.x = MainCamera.transform.position.x * Speed + Scroll + OffSet;
        transform.position = ParallaxFollowCamera;
    }
}
