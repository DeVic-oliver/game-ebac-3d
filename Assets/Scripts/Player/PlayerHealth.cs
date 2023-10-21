namespace Assets.Scripts.Player
{
    using Assets.Scripts.Core.Components;
    using Assets.Scripts.Core.Enum.Item;
    using Assets.Scripts.Core.Interfaces;
    using Assets.Scripts.Items;
    using UnityEngine;

    public class PlayerHealth : Health, IDamageable
    {
        public Inventory Inventory;


        public void SetHealth(int health)
        {
            CurrentHealth = health;
        }

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

            if (Input.GetKeyDown(KeyCode.R) && CurrentHealth < GetTotalHealth())
            {
                RecoverHealth();
            }
        }

        private void RecoverHealth()
        {
            int newHealth = CurrentHealth + Inventory.UseItem(ItemTypes.HeatlhCoin);
            if (newHealth > GetTotalHealth())
            {
                RestoreHealth();
            }
            else
            {
                CurrentHealth = newHealth;
            }
        }
    }
}