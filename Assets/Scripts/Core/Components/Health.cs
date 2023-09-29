using UnityEngine;

namespace Assets.Scripts.Core.Components
{
    public abstract class Health : MonoBehaviour
    {
        public bool IsAlive { get; protected set; }
        public int CurrentHealth { get; protected set; }
        [SerializeField] protected int _health = 100;


        public void RestoreHealth()
        {
            CurrentHealth = _health;
        }

        protected virtual void DecreaseHealth()
        {
            CurrentHealth = GetZeroOrPositiveHealthDecreasedByValue(1);
        }

        protected virtual void DecreaseHealth(int value)
        {
            CurrentHealth = GetZeroOrPositiveHealthDecreasedByValue(value);
        }

        public int GetTotalHealth()
        {
            return _health;
        }

        protected int GetZeroOrPositiveHealthDecreasedByValue(int value)
        {
            var health = CurrentHealth - value;
            if(health < 0)
            {
                return 0;
            }
            return health;
        }

        protected virtual void Start()
        {
            CurrentHealth = _health;
        }

        protected virtual void Update()
        {
            IsAlive = CheckIfIsAliveByHealthAmmout();
        }
        
        protected bool CheckIfIsAliveByHealthAmmout()
        {
            if (CurrentHealth > 0)
            {
                return true;
            }
            return false;
        }

    }
}