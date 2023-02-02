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

        protected virtual void PlayDamageVfx()
        {
            if (_damageVFX != null)
            {
                _damageVFX.Play();
            }
        }
    }
}