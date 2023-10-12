using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFloatBehaviour : StateMachineBehaviour
{
    public string floatName;
    public bool updateOnStateEnter, updateOnStateExit;
    public bool updateStateMachineEnter, updateStateMachineExit;
    public float valueOnEnter, valueOnExit;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(updateOnStateEnter)
        {
            animator.SetFloat(floatName, valueOnEnter);
        }
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    //override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    //{

    //}

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(updateOnStateExit)
        {
            animator.SetFloat(floatName, valueOnExit);
        }
    }

    // OnStateMove is called right after Animator.OnAnimatorMove()
    override public void OnStateMachineEnter(Animator animator, int stateMachinePathHush)
    {
        if(updateStateMachineEnter)
        {
            animator.SetFloat(floatName, valueOnEnter);
        }
    }

    // OnStateIK is called right after Animator.OnAnimatorIK()
    override public void OnStateMachineExit(Animator animator, int stateMachinePathHush)
    {
       if(updateStateMachineExit)
        {
            animator.SetFloat(floatName, valueOnExit);
        }
    }
}
