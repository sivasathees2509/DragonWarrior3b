using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayerState : MonoBehaviour
{
    private static PLayerState _instance;
    public static PLayerState Instance
    {
        get
        {
            if(_instance == null)
                _instance = new GameObject("PlayerState").AddComponent<PLayerState>();
            return _instance;
        }
    }
    public Horizontal Horizontal;
    public Vertical Vertical;
    public DirectionFacing DirectionFacing;
    public Attack Attack;
}

public enum Horizontal
{
    Idle = 0,
    MovingLeft = -1,
    MovingRight = 1,
}

public enum Vertical
{
    Grounded,
    Airborne
}

public enum DirectionFacing
{
    Left = -1,
    Right = 1
}

public enum Attack
{
    Passive,
    Punch,
    Projectile
}

