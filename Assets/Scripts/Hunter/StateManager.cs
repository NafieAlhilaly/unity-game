using System.Collections;
using UnityEngine;
using Platformer.Mechanics;
using Platformer.Mechanics.Fight.FloatingPlatformState;

namespace Hunter
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] FightPlatformsController FPController;
        public BaseState CurrentState;
        public CleaveState CleaveState = new();
        public IdleState IdleState = new();
        public RageState RageState = new();
        public MoveState MoveState = new();
        public FinalAttack FinalAttack = new();
        public bool IsWaiting = true;
        public float ChargeTime = 6;
        public float RageChargeTime = 0;

        void Start()
        {
            CurrentState = IdleState;
            CurrentState.UpdateState(this);
        }

        void Update()
        {
            if(FPController.FPStateManager.CurrentState.GetType() == typeof(FailedState)){
                SwitchState(FinalAttack);
            }
            CurrentState.UpdateState(this);
            if (CurrentState.GetType() == typeof(IdleState) && IsWaiting)
            {
                StartCoroutine(Wait(4f));
            }
        }

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                CurrentState.ApplyPlayerEffect();
            }
        }

        IEnumerator Wait(float seconds)
        {
            IsWaiting = false;
            yield return new WaitForSeconds(seconds);
            if (CleaveState.CleaveCount >= 3)
            {
                SwitchState(RageState);
            }
            else
            {
                SwitchState(CleaveState);
            }
            yield return new WaitForSeconds(seconds * 0.6f);
            IsWaiting = true;
        }

        public void SwitchState(BaseState state)
        {
            CurrentState = state;
            state.StartState(this);
        }
    }
}
