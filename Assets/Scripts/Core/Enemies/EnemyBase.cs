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
        [SerializeField] private int _healthPoints = 5;

        [Header("Damage settings")]
        [SerializeField] private MeshRenderer _enemyMeshRenderer;
        [SerializeField] private Color _damageFeedbackColor;
        [SerializeField] private float _flashSpeed = 1f;
        [SerializeField] private ParticleSystem _damageVFX;

        private Tween _currentColorTween;

        protected virtual void PlayDamageFeedback()
        {
            PlayParticleSystem();
            FlashShader();
        }
        private void PlayParticleSystem()
        {
            if (_damageVFX != null)
            {
                _damageVFX.Play();
            }
        }
        private void FlashShader()
        {
            if (!_currentColorTween.IsActive())
            {
                _currentColorTween = _enemyMeshRenderer.material.DOColor(_damageFeedbackColor, "_EmissionColor", _flashSpeed).SetLoops(2, LoopType.Yoyo);
                _damageVFX.Play();
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
    }
}