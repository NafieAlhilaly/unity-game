namespace Hunter
{

    public class CleaveState : BaseState
    {
        public float CleaveSide = 1f; // 1 = right, -1 = left
        public bool CleaveDone = false;
        public int CleaveCount = 0;
        public override void StartState(StateManager stateManager){
            CleaveCount++;
        }
        public override void UpdateState(StateManager stateManager)
        {
            if (CleaveDone &&  CleaveCount >= 3)
            {
                // TODO: Add rage state for `Hunter` character
                // label: todo
                // milestone: 1
            }
            stateManager.SwitchState(stateManager.IdleState);
        }

        public override void ApplyPlayerEffect()
        {
            CleaveSide *= -1f;
        }
    }
}