namespace Assets.Scripts.Player.State_Machine.Health.States
{
    public class AliveState : HealthStateBase
    {
        public AliveState(HealthStateMachine stateMachine, PlayerHealthAnimator healthAnimator) : base(stateMachine, healthAnimator)
        {
        }

        public override void OnEnter()
        {
            _healthAnimator.SetIsAliveParamToTrue();
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