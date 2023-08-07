using System.Collections;
using UnityEngine;

namespace Hunter
{
    public class StateManager : MonoBehaviour
    {
        BaseState CurrentState;
        public CleaveState CleaveState = new CleaveState();
        public IdleState IdleState = new IdleState();
        bool IsWaiting = true;

        void Start()
        {
            CurrentState = IdleState;
            CurrentState.UpdateState(this);
        }

        void Update()
        {
            CurrentState.UpdateState(this);
            if(CurrentState == IdleState && IsWaiting){
                StartCoroutine(Wait(2f));
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
            SwitchState(CleaveState);
            yield return new WaitForSeconds(seconds*0.6f);
            IsWaiting = true;
        }

        public void SwitchState(BaseState state){
            CurrentState = state;
            state.StartState(this);
        }
    }
}
