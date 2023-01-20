using System;
using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons.Guns
{
    public class Shotgun : GunBase
    {
        [SerializeField] private float _spreadAngle;
        [SerializeField] private float _bulletsQuantityOnShoot;

        
        protected override void CreateBullet()
        {
            base.CreateBullet();

            CreateSpreadedBullets();
        }
        private void CreateSpreadedBullets()
        {
            int spreadMultiplier = 0;
            float spreadAngleAux = _spreadAngle;

            for (int i = 1; i < _bulletsQuantityOnShoot; i++)
            {
                spreadMultiplier = IncrementMultiplierByIndexModZero(spreadMultiplier, i);
                spreadAngleAux = TogglePositiveNegativeByIndexMod(spreadAngleAux, i);
                ShotgunBulletsInstantiation(spreadAngleAux, spreadMultiplier);
            }

            Debug.Log($"All bullets shoot {_bulletsQuantityOnShoot}");
        }
        private int IncrementMultiplierByIndexModZero(int multiplier, int index)
        {
            if(index % 2 == 0)
            {
                return ++multiplier;
            }

            return multiplier;
        }
        private float TogglePositiveNegativeByIndexMod(float number, int index) 
        {
            if(index % 2 == 0)
            {
                return Math.Abs(number);
            }

            return number * -1;
        }
        private void ShotgunBulletsInstantiation(float spread, int spreadMultiplier)
        {
            var bullet = Instantiate(_bulletType);
            bullet.transform.position = _gunBarrel.position;
            bullet.transform.localEulerAngles = Vector3.zero + Vector3.up * (spread * spreadMultiplier);
        }
    }
}