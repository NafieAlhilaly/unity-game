using UnityEngine;

namespace Platformer.Mechanics
{
    public class PatrollerAnimationState : StateMachineBehaviour
    {
        override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.SetBool("IsPlayerDetected", animator.GetComponent<PatrollerController>().IsPlayerDetected);
        }
    }
}