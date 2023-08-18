namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public abstract class HealthStateBase
    {
        protected HealthStateMachine _stateMachine;
        protected PlayerHealthAnimator _healthAnimator;

        public HealthStateBase(HealthStateMachine stateMachine, PlayerHealthAnimator healthAnimator)
        {
            _stateMachine = stateMachine;
            _healthAnimator = healthAnimator;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
    }
}