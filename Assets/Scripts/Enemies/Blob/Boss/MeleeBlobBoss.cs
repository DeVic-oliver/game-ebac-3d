using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Enemies.Blob.Boss
{
    public class MeleeBlobBoss : MeleeEnemy, IDamageable, IMoveable
    {
        public void Move(bool isAlive)
        {
            if(isAlive)
            {
                MoveTowardsEnemy();
            }
        }

        public void TakeDamage(int damageValue)
        {
            DecreaseHealthByDamageWithFlashFeedback(damageValue);
        }

        // Use this for initialization
        new void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            Move(true);
        }
    }
}