using Assets.Scripts.Core.Interfaces;
using UnityEngine;
using DG.Tweening;

namespace Assets.Scripts.Enemies
{
    public class EnemyBase : MonoBehaviour, IDamageable
    {
        public bool IsAlive { get; private set; }
        public bool IsAttacking { get; private set; }

        [SerializeField] private int _healthPoints = 5;

        [SerializeField] private MeshRenderer _enemyMeshRenderer;
        [SerializeField] private Color _damageFeedbackColor;
        [SerializeField] private float _flashSpeed = 1f;

        private Tween _currentColorTween;
        
        public void TakeDamage(int damageValue)
        {
            if (damageValue >= _healthPoints)
            {
                IsAlive = false;
                Destroy(gameObject, 4f);
            }
            else
            {
                _healthPoints -= damageValue;
                PlayDamageFeedback();
            }
        }

        private void PlayDamageFeedback()
        {
            if (!_currentColorTween.IsActive())
            {
                _currentColorTween = _enemyMeshRenderer.material.DOColor(_damageFeedbackColor, "_EmissionColor", _flashSpeed).SetLoops(2, LoopType.Yoyo);
            }
        }

        protected void Start()
        {
            IsAlive = true;
        }

        protected void Update()
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
