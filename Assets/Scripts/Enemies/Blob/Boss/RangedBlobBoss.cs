using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;
using DG.Tweening;

namespace Assets.Scripts.Enemies.Blob
{
    public class RangedBlobBoss : RangedEnemy, IMoveable, IDamageable
    {
        private float _stepToSlerp = 0.7f;

        public void Move(bool isAlive)
        {
            if (isAlive)
            {
                LookToTargetSmoothly();
            }
        }
        private void LookToTargetSmoothly()
        {
            var lookRotation = Quaternion.LookRotation(_enemyGameObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _stepToSlerp * Time.deltaTime);
        }

        public void TakeDamage(int damageValue)
        {
            if(damageValue >= _healthPoints)
            {
                _healthPoints = 0;
                base.PlayVFX(_deathVFX);
            }
            else
            {
                _healthPoints -= damageValue;
                PlayDamageFeedback();
            }
        }
        protected override void PlayDamageFeedback()
        {
            base.FlashShader();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        new void Update()
        {
            base.Update();
            CheckIfEnemyIsNearby();
        }
        private new void CheckIfEnemyIsNearby()
        {
            if (base.CheckIfEnemyIsNearby())
            {
                Move(IsAlive);
            }
        }

    }
}