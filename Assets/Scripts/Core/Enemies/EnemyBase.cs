using DG.Tweening;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Enemies
{
    public abstract class EnemyBase : MonoBehaviour
    {
        public bool IsAlive { get; private set; }
        public bool IsAttacking { get; private set; }

        [Header("Health")]
        [SerializeField] protected int _healthPoints = 5;

        [Header("Damage settings")]
        [SerializeField] private MeshRenderer _enemyMeshRenderer;
        [SerializeField] private Color _damageFeedbackColor;
        [SerializeField] private float _flashSpeed = 1f;
        [SerializeField] protected ParticleSystem _damageVFX;
        [SerializeField] protected ParticleSystem _deathVFX;

        [Header("Detection setup")]
        [SerializeField] protected float _rangeDetection = 15f;
        [SerializeField] protected GameObject _enemyGameObject;


        private Tween _currentColorTween;

        protected virtual void PlayDamageFeedback()
        {
            PlayVFX(_damageVFX);
            FlashShader();
        }
       
        protected void FlashShader()
        {
            if (!_currentColorTween.IsActive())
            {
                _currentColorTween = _enemyMeshRenderer.material.DOColor(_damageFeedbackColor, "_EmissionColor", _flashSpeed).SetLoops(2, LoopType.Yoyo);
            }
        }

        protected virtual void PlayVFX(ParticleSystem particleSys)
        {
            if (particleSys != null)
            {
                particleSys.Play();
            }
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
    }
}