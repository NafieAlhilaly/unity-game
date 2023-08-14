namespace Hunter
{
    public class RageState : BaseState
    {
        public int RageCleaveCount = 0;
        public override void StartState(StateManager stateManager)
        {
            RageCleaveCount += 1;
            stateManager.RageChargeTime = 3;
        }
        public override void UpdateState(StateManager stateManager)
        {
            if (RageCleaveCount >= 3)
            {
                EndRage(stateManager);
            }
        }

        public override void ApplyPlayerEffect() { }

        public void EndRage(StateManager stateManager)
        {
            RageCleaveCount = 0;
            stateManager.CleaveState.CleaveCount = 0;
            stateManager.RageChargeTime = 0;
            stateManager.SwitchState(stateManager.IdleState);
        }
    }
}
