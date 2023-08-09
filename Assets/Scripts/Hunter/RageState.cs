namespace Hunter
{
    public class RageState : BaseState
    {
        public override void StartState(StateManager stateManager)
        {
            stateManager.CleaveState.CleaveSpeed += 0.5f;
        }
        public override void UpdateState(StateManager stateManager) {
            stateManager.SwitchState(stateManager.IdleState);
         }

        public override void ApplyPlayerEffect() { }

        public void EndRage(StateManager stateManager)
        {
            stateManager.SwitchState(stateManager.IdleState);
        }
    }
}
