namespace Assets.Scripts.Player.State_Machine.Health
{
    using Assets.Scripts.Player.State_Machine.Health.States;
    using UnityEngine;
    using UnityEngine.Events;

    public class HealthStateMachine : MonoBehaviour
    {
        public UnityEvent<Transform> OnPlayerDeathSendTransform;
        public UnityEvent OnPlayerDeath;
        public UnityEvent OnPlayerLive;

        public AliveState AliveState;
        public DeadState DeadState;

        [SerializeField] private PlayerHealth _playerHealth;
        private HealthStateBase _currentState;


        public bool IsPlayerAlive()
        {
            return _playerHealth.IsAlive;
        }

        public void InvokeLiveEvents()
        {
            OnPlayerLive.Invoke();
        }

        public void InvokeDeathEvents()
        {
            OnPlayerDeath?.Invoke();
            OnPlayerDeathSendTransform?.Invoke(transform);
        }

        public void SwitchState(HealthStateBase newState)
        {
            _currentState = newState;
            _currentState.OnEnter();
        }

        private void Awake()
        {
            InitializeStates();
        }

        private void InitializeStates()
        {
            AliveState = new(this);
            DeadState = new(this);
        }

        void Start()
        {
            _currentState.OnEnter();
        }

        void Update()
        {
            _currentState.OnUpdate();
        }
    }
}