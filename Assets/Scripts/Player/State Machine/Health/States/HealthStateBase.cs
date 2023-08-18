namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public abstract class HealthStateBase
    {
        protected HealthStateMachine _stateMachine;

        public HealthStateBase(HealthStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }

        public abstract void OnEnter();
        public abstract void OnUpdate();
    }
}