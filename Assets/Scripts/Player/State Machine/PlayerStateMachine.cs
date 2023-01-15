using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player.StateMachine
{
    using Devic.Scripts.Utils.StateMachine;
    using Assets.Scripts.Player.StateMachine.ConcreteStates;
    
    public class PlayerStateMachine : StateMachine
    {
        private enum statesID
        {
            IDLE,
            MOVE,
            RUN,
            DEAD
        }

        private IConcreteState _idleState = new IdleState();

        protected override IConcreteState SetInitialState()
        {
            return _idleState;
        }

        protected override Dictionary<string, IConcreteState> RegisterConcreteStates()
        {
            var registeredStates = new Dictionary<string, IConcreteState>();
            registeredStates.Add(statesID.IDLE.ToString(), _idleState);

            return registeredStates;
        }

        private new void Start()
        {
            base.Start();
        }

        private new void Update()
        {
            base.Update();
        }
    }
}
