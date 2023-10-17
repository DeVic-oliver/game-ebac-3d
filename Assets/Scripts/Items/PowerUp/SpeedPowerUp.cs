namespace Assets.Scripts.Items.PowerUp
{
    using Assets.Scripts.Items.PowerUp.Gateway;
    using UnityEngine;
    
    public class SpeedPowerUp : PowerUp
    {
        [SerializeField] private float _speedValueToIncrease;

        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);

            if(other.TryGetComponent(out MoveSpeedGateway speedGateway))
                speedGateway.AddValueToMoveSpeed(_speedValueToIncrease, _duration);
        }
    }
}