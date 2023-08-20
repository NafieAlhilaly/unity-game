using System.Collections;
using JetBrains.Annotations;
using UnityEngine;


namespace Platformer.Mechanics.Fight.FloatingPlatformState
{
    public class StateManager : MonoBehaviour
    {
        [SerializeField] public FightPlatformsController FightPlatformsController;
        public bool ReadyForCalculationPuzzle = false;
        public BaseState CurrentState;
        public IdleState IdleState = new();
        public PrepareCalculationPuzzleState PrepareCalculationPuzzleState = new();
        public CheckResultState CheckResultState = new();
        public FailedState FailedState = new();

        void Start()
        {
            CurrentState = IdleState;
        }

        void Update()
        {
            if (ReadyForCalculationPuzzle && CurrentState.GetType() == typeof(IdleState))
            {
                SwitchState(PrepareCalculationPuzzleState);
            }
        }

        public void SwitchState(BaseState state)
        {
            CurrentState = state;
            state.StartState(this);
        }

        public void ShowOptions()
        {
            StartCoroutine(FightPlatformsController.PlayPlatformEffect());
        }
        public void HideOptions()
        {
            StartCoroutine(FightPlatformsController.StopPlatformEffect());
        }
        public void StartSwitchStateAfterSeconds(BaseState state, float seconds)
        {
            StartCoroutine(SwitchStateAfterSeconds(state, seconds));
        }
        IEnumerator SwitchStateAfterSeconds(BaseState state, float seconds)
        {
            yield return new WaitForSeconds(seconds);
            SwitchState(state);
        }

    }
}