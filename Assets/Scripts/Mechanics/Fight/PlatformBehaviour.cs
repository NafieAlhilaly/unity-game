using UnityEngine;

namespace Platformer.Mechanics
{

    public class PlatformBehaviuor : MonoBehaviour
    {
        [SerializeField] FightPlatformsController fc;
        [SerializeField] int number;

        void OnTriggerEnter2D(Collider2D col)
        {
            if (col.CompareTag("Player") && fc.FPStateManager.CurrentState.GetType() == fc.FPStateManager.PrepareCalculationPuzzleState.GetType())
            {
                fc.SelectedNumber = number;
                foreach (ParticleSystem ps in fc.UpperPlatformPSs)
                {
                    ps.Stop();
                }
                fc.UpperPlatformPSs[number - 1].Play();
            }
        }
    }
}
