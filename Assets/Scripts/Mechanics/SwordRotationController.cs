using UnityEngine;

public class SwordMovementController : StateMachineBehaviour
{
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        animator.GetComponent<SwordBehavior>().RotateToTarget(target);  
    }
}
