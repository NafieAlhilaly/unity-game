using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Platformer.Core;

namespace Hunter
{
    public class MoveState : BaseState
    {
        public float x, y;
        public override void ApplyPlayerEffect(){}

        public override void StartState(StateManager stateManager){
            stateManager.IsWaiting = false;
        }

        public override void UpdateState(StateManager stateManager){}
    }

}