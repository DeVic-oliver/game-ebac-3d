namespace Assets.Scripts.Enemies.Blob.BloblProjectiles
{
    using Assets.Scripts.Core.Components.Projectile;
    using Assets.Scripts.Player;
    using UnityEngine;
    
    public class AcidSpit : Projectile
    {
        protected override void Update()
        {
            base.Update();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerHealthDamageGateway>(out var healthGateway))
            {
                int randomDamage = Random.Range(16, 40);
                healthGateway.SendDamageToHealthComponent(randomDamage);
            }
        }
    }
}