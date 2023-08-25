using UnityEngine;

namespace Platformer.Mechanics.Fight.FloatingPlatformState
{

    public class PrepareCalculationPuzzleState : BaseState
    {
        public int Divisible = 0;
        int RndNumber = 0;
        public int SelectedCalculationPuzzle = 1;
        public override void StartState(StateManager stateManager)
        {
            RndNumber = Random.Range(1, 3);
            SelectCalculationPuzzleByNumber(RndNumber, stateManager);
        }

        public override void UpdateState(StateManager stateManager)
        {
        }

        void SelectCalculationPuzzleByNumber(int number, StateManager stateManager)
        {
            int RndNumber = Random.Range(1, 6);
            if (number == 1)
            {
                SelectedCalculationPuzzle = 1;
                Divisible = CalculationPuzzle.DivisibleBy(RndNumber, 5);
                stateManager.FightPlatformsController.Console.text += "\n \t Test Divisible by " + Divisible.ToString();
                stateManager.ShowOptions();
                stateManager.StartSwitchStateAfterSeconds(stateManager.CheckResultState, 13);
            }
            if (number == 2)
            {
                SelectedCalculationPuzzle= 2;
                stateManager.FightPlatformsController.Console.text += "\n \t Test Indivisible ";
                stateManager.ShowOptions();
                stateManager.StartSwitchStateAfterSeconds(stateManager.CheckResultState, 13);
            }
        }
    }
}