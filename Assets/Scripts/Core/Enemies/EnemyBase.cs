using DG.Tweening;
using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Components.Damage;

namespace Assets.Scripts.Core.Enemies
{
    [RequireComponent(typeof(DamageComponent))]
    public abstract class EnemyBase : MonoBehaviour
    {
        public bool IsAlive { get; private set; }
        public bool IsAttacking { get; private set; }

        [Header("Health")]
        [SerializeField] protected int _healthPoints = 5;

        [Header("Detection setup")]
        [SerializeField] protected float _rangeDetection = 15f;
        [SerializeField] protected GameObject _enemyGameObject;
        [SerializeField] private float _rotationSlerpStep = 0.7f;


        [SerializeField] protected DamageComponent _damageComponent;

        protected virtual void Start()
        {
            _damageComponent = GetComponent<DamageComponent>();
        }

        protected virtual void Update()
        {
            IsAlive = CheckIfHasHealthPoints();
        }
        private bool CheckIfHasHealthPoints()
        {
            if (_healthPoints > 0)
            {
                return true;
            }

            return false;
        }

        protected virtual bool CheckIfEnemyIsNearby()
        {
            if(Vector3.Distance(_enemyGameObject.transform.position, gameObject.transform.position) < _rangeDetection)
            {
                return true;
            }
            return false;
        }

        protected void LookToTargetSmoothly()
        {
            var lookRotation = Quaternion.LookRotation(_enemyGameObject.transform.position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, _rotationSlerpStep * Time.deltaTime);
        }

        protected void DecreaseHealthByDamageWithFlashFeedback(int damage)
        {
            if (damage >= _healthPoints)
            {
                _healthPoints = 0;
            }
            else
            {
                _damageComponent.FlashShader();
                _healthPoints -= damage;
            }
        }
    }
}