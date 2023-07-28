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
        [SerializeField] readonly GameObject Player;
        [SerializeField] readonly float step = 0.1f;
        [SerializeField] readonly ParticleSystem ps;
        public static int DeathCount = 0;
        [SerializeField] readonly int chasingCountModifier = 0;

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
