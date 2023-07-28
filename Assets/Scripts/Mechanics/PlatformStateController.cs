using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlatformStateController : StateMachineBehaviour
    {
        GameObject FlyingPlatform;
        GameObject GroundPplatform;
        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
           FlyingPlatform = GameObject.FindGameObjectWithTag("FlyingPlatform");
           GroundPplatform = GameObject.FindGameObjectWithTag("GoundPlatform");
           animator.GetComponent<RobocatBehavior>().PrepareMovingObjectTo(FlyingPlatform, new Vector3(-56.52f, 1.55f, 0), 1);
           animator.GetComponent<RobocatBehavior>().PrepareMovingObjectTo(GroundPplatform, new Vector3(5.6f, -8.7f), 1);
        }
    }
}
