using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemies;
using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;

namespace Assets.Scripts.Enemies.Blob
{

    public class MeleeBlobMinion : MeleeEnemy, IDamageable, IMoveable
    {
        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();
            Move(IsAlive);
        }

        public void TakeDamage(int damageValue)
        {
            throw new System.NotImplementedException();
        }

        public void Move(bool isAlive)
        {
            if (isAlive && base.CheckIfEnemyIsNearby())
            {
                MoveTowardsEnemy();
            }
        }
       
    }
}

