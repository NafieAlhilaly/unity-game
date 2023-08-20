namespace Platformer.Mechanics.Fight.FloatingPlatformState
{
    public abstract class BaseState
    {
        public abstract void StartState(StateManager stateManager);
        public abstract void UpdateState(StateManager stateManager);
    }
}