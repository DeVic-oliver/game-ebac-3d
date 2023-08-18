namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public class AliveState : HealthStateBase
    {
        public AliveState(HealthStateMachine stateMachine) : base(stateMachine)
        {
        }

        public override void OnEnter()
        {
            _stateMachine.InvokeLiveEvents();
        }

        public override void OnUpdate()
        {
            if (!_stateMachine.IsPlayerAlive())
            {
                _stateMachine.SwitchState(_stateMachine.DeadState);
            }
        }
    }
}