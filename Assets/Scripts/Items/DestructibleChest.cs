namespace Assets.Scripts.Items
{
    using Assets.Scripts.Core.Interfaces;
    using DG.Tweening;
    using UnityEngine;
    
    public class DestructibleChest : MonoBehaviour, IDamageable
    {
        public GameObject ItemToDrop;
        public Collider Collider;
        public int Health = 15;


        public void TakeDamage(int damageValue)
        {
            if(Health > 0)
            {
                Health -= damageValue;
                transform.DOShakeScale(.5f, 1);
                Instantiate(ItemToDrop, transform.position + new Vector3(0, 5, 0), transform.rotation);
            }
        }

        private void Update()
        {
            if(Health <= 0)
            {
                Collider.enabled = false;
                transform.DOScale(0, 1.5f);
            }
        }

    }
}