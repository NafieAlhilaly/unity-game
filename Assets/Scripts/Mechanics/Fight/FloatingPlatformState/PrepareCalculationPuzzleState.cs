using UnityEngine;

namespace Platformer.Mechanics.Fight.FloatingPlatformState
{

    public class PrepareCalculationPuzzleState : BaseState
    {
        public int Divisible = 0;
        int RndNumber = 0;
        public override void StartState(StateManager stateManager)
        {
            RndNumber = Random.Range(1, 6);
            Divisible = CalculationPuzzle.DivisibleBy(RndNumber, 5);
            stateManager.FightPlatformsController.Console.text += "\n \t Test Divisible by " + Divisible.ToString();
            stateManager.ShowOptions();
            stateManager.StartSwitchStateAfterSeconds(stateManager.CheckResultState, 13);
        }

        public override void UpdateState(StateManager stateManager)
        {
        }
    }
}