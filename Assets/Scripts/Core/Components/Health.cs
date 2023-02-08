using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.Core.Components
{
    public class Health : MonoBehaviour
    {
        public bool IsAlive { get; private set; }

        [SerializeField] private float _health = 100f;
        [SerializeField] private Image _healthBar;

        private float _currentHealth;

        public void DecreaseHealth()
        {
            _health = GetZeroOrPositiveHealthDecreasedByValue(1f);
        }

        public void DecreaseHealth(float value)
        {
            _health = GetZeroOrPositiveHealthDecreasedByValue(value);
        }

        private float GetZeroOrPositiveHealthDecreasedByValue(float value)
        {
            var health = _health - value;
            if(health < 0)
            {
                return 0;
            }
            return health;
        }

        private void Start()
        {
            _currentHealth = _health;
        }

        private void Update()
        {
            _healthBar.fillAmount = GetHealthPercentage();
            IsAlive = CheckIfIsAliveByHealthAmmout();
        }
        private float GetHealthPercentage()
        {
            var percentage = (_currentHealth * 100f) / _health;
            percentage = GetNormalizedPercentage(percentage);
            return percentage;
        }
        private float GetNormalizedPercentage(float value) 
        {
            return value / 100f;
        }
        private bool CheckIfIsAliveByHealthAmmout()
        {
            if(_health > 0)
            {
                return true;
            }
            return false;
        }

    }
}