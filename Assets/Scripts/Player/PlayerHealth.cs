namespace Assets.Scripts.Player
{
    using Assets.Scripts.Core.Components;
    using Assets.Scripts.Core.Interfaces;
    

    public class PlayerHealth : Health, IDamageable
    {
        public void TakeDamage(int damageValue)
        {
            DecreaseHealth(damageValue);
        }

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();
        }
    }
}