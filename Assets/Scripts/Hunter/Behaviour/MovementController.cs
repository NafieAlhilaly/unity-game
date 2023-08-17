using Platformer.Core;
using Platformer.Mechanics;
using UnityEngine;

namespace Hunter.Behaviour
{
    public class MovementController : MonoBehaviour
    {
        [SerializeField] StateManager StateManager;
        [SerializeField] int ScreenPadding = 3;
        [SerializeField] float steps = 2;
        [SerializeField] PatrolPath Path;

        IdleState IdleState = new();
        float RandomXPoint;
        float RandomYPoint;
        void Start()
        {
            RandomXPoint = Fuzzy.ValueBetween(Path.startPosition.x, Path.endPosition.x);
            RandomYPoint = Fuzzy.ValueBetween(Path.startPosition.y, Path.endPosition.y);
        }
        void Update()
        {
            if (StateManager.CurrentState.GetType() == typeof(MoveState))
            {
                Vector3 Target = new(RandomXPoint, RandomYPoint, transform.position.z);
                transform.position = Vector3.MoveTowards(transform.position, Target, Time.deltaTime * steps);
                if (ArrivedAtTarget(transform.position, Target))
                {
                    StateManager.IsWaiting = true;
                    StateManager.SwitchState(IdleState);
                    RandomXPoint = Fuzzy.ValueBetween(Path.startPosition.x, Path.endPosition.x);
                    RandomYPoint = Fuzzy.ValueBetween(Path.startPosition.y, Path.endPosition.y);
                }
            }
        }

        bool ArrivedAtTarget(Vector3 currentPosition, Vector3 distance)
        {
            return currentPosition.x == distance.x && currentPosition.y == distance.y;
        }
    }
}