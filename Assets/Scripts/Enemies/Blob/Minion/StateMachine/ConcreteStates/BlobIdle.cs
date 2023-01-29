using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Blob.Minion.StateMachine.ConcreteStates
{
    using Devic.Scripts.Utils.StateMachine;

    public class BlobIdle : IConcreteState
    {
        private Animator _animator;
        private BlobMinion _blobMinion;

        public BlobIdle(Animator animator, BlobMinion blobMinion)
        {
            _animator = animator;
            _blobMinion = blobMinion;
        }

        public void OnStateEnter(StateMachine stateMachine)
        {
            _animator.SetTrigger("IDLE");
        }

        public void OnUpdateState(StateMachine stateMachine)
        {
            if (!_blobMinion.IsAlive)
            {
                stateMachine.SwitchState("DEAD");
            }
        }
    }
}