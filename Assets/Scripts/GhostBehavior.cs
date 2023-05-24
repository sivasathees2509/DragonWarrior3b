using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Ghost))]      // GhostBehavoiur work with help of ghost

public abstract class GhostBehavior : MonoBehaviour   //abstract, never have a ghost behaviour by itself, we can never add a ghost beh to any game object
{
    public Ghost ghost { get; private set; }

    public float duration;

    private void Awake()
    {
        this.ghost = GetComponent<Ghost>();
        this.enabled = false;                //Immediately diasable the script
    }
     
    public void Enable()      //this call the function Virtual void Enable
    {
        Enable(this.duration);    // Duration mentioned in the inspector
    }


    public virtual void Enable(float duration)   // Enabling for some duration (eg. power pellet duration)
    {
        this.enabled = true;

        CancelInvoke();                          // if we eat the power pellet again on the frightened mode, to reset the duration we cancelinvoke
        Invoke(nameof(Disable), duration); 
    }

    public virtual void Disable()
    {
        this.enabled = false;
        CancelInvoke();
    }
}
