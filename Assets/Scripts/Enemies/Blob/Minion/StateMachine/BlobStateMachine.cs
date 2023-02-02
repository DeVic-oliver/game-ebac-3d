//using System.Collections;
//using UnityEngine;

//namespace Assets.Scripts.Enemies.Blob.Minion.StateMachine
//{
//    using Assets.Scripts.Enemies.Blob.Minion.StateMachine.ConcreteStates;
//    using Devic.Scripts.Utils.StateMachine;
//    using System.Collections.Generic;

//    public class BlobStateMachine : StateMachine
//    {
//        #region STATES
//        private enum statesID
//        {
//            IDLE,
//            MOVE,
//            RUN,
//            DEAD
//        }
//        #endregion
//        private IConcreteState _idleState;
//        private IConcreteState _deadState;

//        private BlobMinion _blobMinion;
//        [SerializeField] private Animator _animator;



//        protected override Dictionary<string, IConcreteState> RegisterConcreteStates()
//        {
//            InitObjects();
//            var registeredStates = new Dictionary<string, IConcreteState>();
//            registeredStates.Add(statesID.IDLE.ToString(), _idleState);
//            registeredStates.Add(statesID.DEAD.ToString(), _deadState);
//            return registeredStates;
//        }
//        private void InitObjects()
//        {
//            _blobMinion = GetComponent<BlobMinion>();
//            _idleState = new BlobIdle(_animator, _blobMinion);
//            _deadState = new BlobDead(_animator, _blobMinion);
//        }
//        protected override IConcreteState SetInitialState()
//        {
//            return _idleState;
//        }

//        // Use this for initialization
//        new void Start()
//        {
//            base.Start();
//        }

//        // Update is called once per frame
//        new void Update()
//        {
//            base.Update();
//        }
//    }
//}