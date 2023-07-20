using UnityEngine;
using System.Collections;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Platformer.Mechanics
{
    /// <summary>
    /// This class defines the behavior of the Ghost enemy.
    /// </summary>
    public class GhostController : MonoBehaviour
    {
        [SerializeField] public SpriteRenderer GhostSprite;
        [SerializeField] GameObject Player;
        [SerializeField] float step = 0.1f;
        [SerializeField] ParticleSystem ps;
        private enum GhostState { Idle, Active, dead };
        [SerializeField] GhostState state = GhostState.Idle;
        public static int DeathCount = 0;
        [SerializeField] int chasingCountModifier = 0;

        void Update()
        {
            if (DeathCount >= chasingCountModifier)
            {
                transform.LookAt(Player.transform);
                transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Time.deltaTime * step);
            }
        }

        void Start()
        {
            ps.Stop();
        }

        public void Death()
        {
            StartCoroutine(DeathProccess());
            DeathCount++;
        }

        void OnCollisionEnter2D(Collision2D collision)
        {
            var Mace = collision.gameObject.GetComponent<MaceAttackController>();
            if (Mace != null)
            {
                GhostMaceCollision ev = Schedule<GhostMaceCollision>();
                ev.Mace = Mace;
                ev.Ghost = this;
            }
        }

        IEnumerator DeathProccess()
        {
            ps.Play();
            GhostSprite = null;
            yield return new WaitForSeconds(0.3f);
            ps.Stop();
            gameObject.SetActive(false);
        }
    }
}
