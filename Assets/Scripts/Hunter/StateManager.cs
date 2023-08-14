using System.Collections;
using UnityEngine;

namespace Hunter
{
    public class StateManager : MonoBehaviour
    {
        public BaseState CurrentState;
        public CleaveState CleaveState = new();
        public IdleState IdleState = new();
        public RageState RageState = new();
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
            Debug.Log(CurrentState);
            CurrentState.UpdateState(this);
            if (CurrentState == IdleState && IsWaiting)
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
