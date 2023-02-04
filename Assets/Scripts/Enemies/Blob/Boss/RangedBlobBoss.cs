using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;
using DG.Tweening;

namespace Assets.Scripts.Enemies.Blob
{
    public class RangedBlobBoss : RangedEnemy, IMoveable, IDamageable
    {

        public void Move(bool isAlive)
        {
            if (isAlive && base.CheckIfEnemyIsNearby()) 
            {
                LookToTargetSmoothly();
            }
        }

        public void TakeDamage(int damageValue)
        {
           DecreaseHealthByDamageWithFlashFeedback(damageValue);
        }
        private void PlayDamageFeedback()
        {
            _damageComponent.FlashShader();
        }

        new void Start()
        {
            base.Start();
        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            Move(IsAlive);
        }

    }
}