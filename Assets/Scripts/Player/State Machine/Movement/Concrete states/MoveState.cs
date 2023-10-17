using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Player.StateMachine.ConcreteStates
{
    using Devic.Scripts.Utils.StateMachine;

    public class MoveState : IConcreteState
    {
        private Animator _animator;
        private PlayerMovement _playerMovement;

        public MoveState() { }
        
        public MoveState(Animator animator, PlayerMovement playerMovment)
        {
            _animator = animator;
            _playerMovement = playerMovment;
        }

        public void OnStateEnter(StateMachine stateMachine)
        {
            _animator.SetBool("move", true);
        }

        public void OnUpdateState(StateMachine stateMachine)
        {
            if(_playerMovement != null && !_playerMovement.IsMoving)
            {
                _animator.SetBool("move", false);
                stateMachine.SwitchState("IDLE");
            }
            else
            {
                //Debug.Log("Running MOVE STATE");
            }
        }
    }
}