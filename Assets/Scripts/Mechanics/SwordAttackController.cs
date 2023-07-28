using UnityEngine;

public class SwordAttackController : StateMachineBehaviour
{
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        Transform target = GameObject.FindGameObjectWithTag("Player").transform;
        animator.GetComponent<SwordBehavior>().PrepareToAttack(target, 0.6f); 
    }
}
