using UnityEngine;
using Platformer.Mechanics;

namespace Hunter.Behaviour
{
    public class AutoAttack : MonoBehaviour
    {
        public float RotationSpeed = 0.3f;
        private Quaternion LookRotation;
        private Vector3 Direction;
        [SerializeField] GameObject Player;
        [SerializeField] float AngleModifier = 30f;
        [SerializeField] Shot ElectricShot;
        public enum AttackState
        {
            Idle,
            Charging,
            Attacking,
            Stop
        }
        [SerializeField] public AttackState CurrentAttackState = AttackState.Idle;

        void Update()
        {
            RotateToTarget(Player.transform);
            if (CurrentAttackState == AttackState.Idle)
            {
                CurrentAttackState = AttackState.Charging;
                Invoke(nameof(InstantiateAttack), 6f);
            }
        }

        public void RotateToTarget(Transform Target)
        {
            Direction = (Target.position - transform.position).normalized;
            float angle = (Mathf.Atan2(Direction.y, Direction.x) * Mathf.Rad2Deg) + AngleModifier;
            LookRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            transform.rotation = Quaternion.Slerp(transform.rotation, LookRotation, Time.deltaTime * RotationSpeed);
        }

        void InstantiateAttack()
        {
            CurrentAttackState = AttackState.Attacking;
            ElectricShot.Player = Player;
            Shot s = Instantiate(ElectricShot, transform);
            CurrentAttackState = AttackState.Idle;
        }
    }

}