using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlatformStateController : StateMachineBehaviour
    {
        GameObject FlyingPlatform;
        GameObject GroundPplatform;
        // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           FlyingPlatform = GameObject.FindGameObjectWithTag("FlyingPlatform");
           GroundPplatform = GameObject.FindGameObjectWithTag("GoundPlatform");
           animator.GetComponent<RobocatBehavior>().prepareMovingObjectTo(FlyingPlatform, new Vector3(-56.52f, 1.55f, 0), 1);
           animator.GetComponent<RobocatBehavior>().prepareMovingObjectTo(GroundPplatform, new Vector3(5.6f, -8.7f), 1);
        }

        // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
        // override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        // {
           
        // }

        // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
        //override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    
        //}

        // OnStateMove is called right after Animator.OnAnimatorMove()
        //override public void OnStateMove(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that processes and affects root motion
        //}

        // OnStateIK is called right after Animator.OnAnimatorIK()
        //override public void OnStateIK(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        //{
        //    // Implement code that sets up animation IK (inverse kinematics)
        //}
    }
}
