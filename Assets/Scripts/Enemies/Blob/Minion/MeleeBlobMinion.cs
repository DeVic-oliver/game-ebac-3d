using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemies;
using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;
using DG.Tweening;

namespace Assets.Scripts.Enemies.Blob
{

    public class MeleeBlobMinion : MeleeEnemy, IDamageable, IMoveable, IPushable
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
            DecreaseHealthByDamageWithFlashFeedback(damageValue);
            PlayDamageComponentVFX("bloodSpill");
        }

        public void Move(bool isAlive)
        {
            if (isAlive && base.CheckIfEnemyIsNearby())
            {
                MoveTowardsEnemy();
            }
        }

        public void Push(Vector3 force)
        {
            var forceVector = new Vector3(transform.localPosition.x - force.z, transform.position.y, transform.localPosition.z - force.z);
            transform.DOMove(forceVector, .1f);
        }
    }
}

