using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.StateMachine.ConcreteStates
{
    using Devic.Scripts.Utils.StateMachine;

    public class IdleState : IConcreteState
    {
        public void OnStateEnter(StateMachine stateMachine)
        {
            Debug.Log("Entered in IDLE state");
        }

        public void OnUpdateState(StateMachine stateMachine)
        {
            Debug.Log("Runnig in IDLE state");
        }
    }
}