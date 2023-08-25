using UnityEngine;

namespace Platformer.Mechanics.Fight.FloatingPlatformState
{

    public class CheckResultState : BaseState
    {
        public override void StartState(StateManager stateManager)
        {
            stateManager.HideOptions();
            if (stateManager.PrepareCalculationPuzzleState.SelectedCalculationPuzzle == 2)
            {
                bool Indivisible = CalculationPuzzle.Indivisible(stateManager.FightPlatformsController.SelectedNumber);
                if (Indivisible)
                {
                    stateManager.FightPlatformsController.Console.text += "... Passed";
                    stateManager.StartSwitchStateAfterSeconds(stateManager.IdleState, 7);
                }
                else
                {
                    stateManager.FightPlatformsController.Console.text += "... Failed";
                    stateManager.SwitchState(stateManager.FailedState);
                }
            }
            if (stateManager.PrepareCalculationPuzzleState.SelectedCalculationPuzzle == 1)
            {
                if (stateManager.FightPlatformsController.SelectedNumber == stateManager.PrepareCalculationPuzzleState.Divisible)
                {
                    stateManager.FightPlatformsController.Console.text += "... Passed";
                    stateManager.StartSwitchStateAfterSeconds(stateManager.IdleState, 7);
                }
                else
                {
                    stateManager.FightPlatformsController.Console.text += "... Failed";
                    stateManager.SwitchState(stateManager.FailedState);
                }
            }
        }

        public override void UpdateState(StateManager stateManager)
        {
        }
    }
}