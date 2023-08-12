using UnityEngine;
using Platformer.Mechanics;
using Platformer.Gameplay;
using static Platformer.Core.Simulation;

namespace Hunter.Behaviour
{
    public class CleaveController : MonoBehaviour
    {
        [SerializeField] StateManager StateManager;
        [SerializeField] ParticleSystem CleaveEffect;
        [SerializeField] ParticleSystem MeteorAtackEffect;
        [SerializeField] AudioSource ChagringSound;
        [SerializeField] bool TriggerDeathZone = false;
        float CurrentCleaveSide = -1;
        enum CleaveAttackState { Idle, Charging, Attacking }
        [SerializeField] CleaveAttackState AttackState = CleaveAttackState.Idle;
        void Start()
        {
            CleaveEffect.Stop();
            MeteorAtackEffect.Stop();
            ChagringSound.Stop();
        }
        void Update()
        {
            if (StateManager.CurrentState.GetType() == typeof(CleaveState))
            {
                if (CurrentCleaveSide != StateManager.CleaveState.CleaveSide && AttackState == CleaveAttackState.Charging)
                {
                    float CleaveSide = StateManager.CleaveState.CleaveSide < 0 ? 0 : 180;
                    transform.Rotate(0, 0, CleaveSide);
                    CurrentCleaveSide = StateManager.CleaveState.CleaveSide;
                }
                if (AttackState == CleaveAttackState.Idle)
                {

                    int[] Sides = new[] { -1, 1 };
                    int RndIndex = Random.Range(0, 2);
                    StateManager.CleaveState.CleaveSide = Sides[RndIndex];
                    Invoke(nameof(Attack), StateManager.CleaveState.ChargeTime);
                    ChagringSound.Play();
                    CleaveEffect.Play();
                    AttackState = CleaveAttackState.Charging;
                }
            }

        }

        void OnTriggerEnter2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null && TriggerDeathZone)
            {
                Schedule<PlayerEnteredDeathZone>();
            }
        }
        void OnTriggerStay2D(Collider2D collider)
        {
            var p = collider.gameObject.GetComponent<PlayerController>();
            if (p != null && TriggerDeathZone)
            {
                Schedule<PlayerEnteredDeathZone>();
            }
        }

        void Attack()
        {
            AttackState = CleaveAttackState.Attacking;
            CleaveEffect.Stop();
            MeteorAtackEffect.Play();
            TriggerDeathZone = true;
            Invoke(nameof(EndAttack), 2f);
        }

        void EndAttack()
        {
            TriggerDeathZone = false;
            MeteorAtackEffect.Stop();
            StateManager.SwitchState(StateManager.IdleState);
            AttackState = CleaveAttackState.Idle;
        }
    }

}