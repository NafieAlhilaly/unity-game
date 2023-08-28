using Platformer.Gameplay;
using UnityEngine;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// DeathZone components mark a collider which will schedule a
    /// PlayerEnteredDeathZone event when the player enters the trigger.
    /// </summary>
    public class DeathZone : MonoBehaviour
    {
        [SerializeField] FlushScreen FS;
        [SerializeField] bool IsBossFight = false;
        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null)
            {
                if (IsBossFight && FS != null)
                {
                    Schedule<SceneRestart>(1.5f);
                    FS.StartFlushing();
                }
                else
                {
                    var ev = Schedule<PlayerEnteredDeathZone>();
                    ev.deathzone = this;
                }
            }
        }
    }
}