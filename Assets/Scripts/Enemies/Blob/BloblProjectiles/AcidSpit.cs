using Assets.Scripts.Core.Components.Projectile;
using Assets.Scripts.Player;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Blob.BloblProjectiles
{
    public class AcidSpit : Projectile
    {

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
       new void Update()
        {
            base.Update();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.TryGetComponent<PlayerHealthDamageGateway>(out var healthGateway))
            {
                int randomDamage = Random.Range(2, 6);
                healthGateway.SendDamageToHealthComponent(randomDamage);
            }
        }
    }
}