using UnityEngine;

namespace Platformer.Mechanics
{
    public class RobocatMovementController : StateMachineBehaviour
    {
        public float MovementSpeed = 4f;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.GetComponent<RobocatBehavior>().PrepareMovingToRandomPosition();
        }
    }
}