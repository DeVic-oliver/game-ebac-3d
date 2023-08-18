namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public class DeadState : HealthStateBase
    {
        public DeadState(HealthStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            _stateMachine.InvokeDeathEvents();
        }

        public override void OnUpdate()
        {
            if (_stateMachine.IsPlayerAlive())
            {
                _stateMachine.SwitchState(_stateMachine.AliveState);
            }
        }
    }
}