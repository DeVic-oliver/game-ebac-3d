namespace Assets.Scripts.Player
{
    using UnityEngine;
    
    public class PlayerHealthDamageGateway : MonoBehaviour
    {
        [SerializeField] private PlayerHealth _health;

        public void SendDamageToHealthComponent(int damage)
        {
            _health.TakeDamage(damage);
        }
    }
}