using UnityEngine;

namespace Hunter
{

    public class CleaveState : BaseState
    {
        public float CleaveSide = -1f; // 1 = right, -1 = left
        public bool CleaveDone = false;
        public int CleaveCount = 0;
        public float CleaveSpeed = 1f;
        [SerializeField] public float ChargeTime = 6f;
        public override void StartState(StateManager stateManager){
            CleaveCount++;
        }
        public override void UpdateState(StateManager stateManager)
        {
            if (CleaveDone &&  CleaveCount >= 3)
            {
                stateManager.SwitchState(stateManager.RageState);
            }
        }

        public override void ApplyPlayerEffect()
        {
            CleaveSide *= -1f;
        }
    }
}