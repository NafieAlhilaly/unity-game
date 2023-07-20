using UnityEngine;

namespace Platformer.Mechanics
{
    public class MaceAttackController : MonoBehaviour
    {
        enum MaceState
        {
            Attacking,
            Idle
        }
        [SerializeField] MaceState MaceCurrentState = MaceState.Idle;
        [SerializeField] float SpeedModifier = 2f;
        [SerializeField] PatrolPath PatrolPath;
        [SerializeField] bool IsPlayerIn = false;

        void OnTriggerEnter2D(Collider2D collider)
        {
            var player = collider.gameObject.GetComponent<PlayerController>();
            if (player != null && MaceCurrentState == MaceState.Idle)
            {
                IsPlayerIn = true;
            }
        }

        void Update(){
            if(MaceCurrentState == MaceState.Idle && IsPlayerIn == true){
                Attack();
            }
            if(transform.position.y <= PatrolPath.endPosition.y){
                transform.position = PatrolPath.startPosition;
                IsPlayerIn = false;
            }
        }

        void Attack()
        {
            transform.position = transform.position + Vector3.down * Time.deltaTime * SpeedModifier;
        }

        void Awake(){
            PatrolPath.startPosition = transform.position;

        }
    }
}