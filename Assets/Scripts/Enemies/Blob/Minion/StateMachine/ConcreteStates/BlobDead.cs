//using System.Collections;
//using UnityEngine;

//namespace Assets.Scripts.Enemies.Blob.Minion.StateMachine.ConcreteStates
//{
//    using Devic.Scripts.Utils.StateMachine;
//    public class BlobDead : IConcreteState
//    {
//        private Animator _animator;
//        private BlobMinion _blobMinion;

//        public BlobDead(Animator animator, BlobMinion blobMinion) 
//        { 
//            _animator = animator;
//            _blobMinion = blobMinion;
//        }

//        public void OnStateEnter(StateMachine stateMachine)
//        {
//            _animator.SetTrigger("DEAD");
//            _blobMinion.PlayDeathVFX();
//        }

//        public void OnUpdateState(StateMachine stateMachine)
//        {
//            Debug.Log("I AM DEAD");
//        }
//    }
//}