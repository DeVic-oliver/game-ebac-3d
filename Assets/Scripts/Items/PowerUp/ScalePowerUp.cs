namespace Assets.Scripts.Items.PowerUp
{
    using Assets.Scripts.Items.PowerUp.Gateway;
    using UnityEngine;
    
    public class ScalePowerUp : PowerUp
    {
        [SerializeField] private float _scaleMultiplier;


        protected override void OnTriggerEnter(Collider other)
        {
            base.OnTriggerEnter(other);
            if (other.TryGetComponent(out ScaleGateway scaleGateway))
                scaleGateway.IncreaseScale(_scaleMultiplier, _duration);
        }
    }
}