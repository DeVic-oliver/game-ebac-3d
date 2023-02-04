using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Components.Weapon
{
    using Assets.Scripts.Core.Components.Projectile;
    using Assets.Scripts.Core.Enemies;

    public class RangedWeapon : MonoBehaviour
    {
        [Header("Weapon Setup")]
        [SerializeField] protected Transform _weaponPosition;
        [SerializeField] protected Projectile _projectile;
        [SerializeField] protected float _intervalBetweenShoots;
        [SerializeField] protected int _ammoAmount;
        [SerializeField] protected float _reloadTimeSeconds = 2f;


        public void Shoot()
        {
            StartCoroutine(ShootProjectile());
        }

        public void StopShoot()
        {
            StopCoroutine(ShootProjectile());
        }

        IEnumerator ShootProjectile()
        {
            int shootsMade = 0;
            float reloadCount = 0;
            while (shootsMade < _ammoAmount)
            {
                shootsMade++;
                ShootProjectileFromWeaponPosition();
                yield return new WaitForSeconds(_intervalBetweenShoots);
            }
            
            while(reloadCount < _reloadTimeSeconds)
            {
                reloadCount += Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }
            shootsMade = 0;
        }

        protected virtual void ShootProjectileFromWeaponPosition()
        {
            if (_projectile != null)
            {
                Instantiate(_projectile, _weaponPosition.position, _weaponPosition.rotation);
                RemoveParent(_projectile.gameObject);
            }
        }
        private void RemoveParent(GameObject gameObject)
        {
            if(gameObject.transform.parent != null) 
            {
                gameObject.transform.parent = null;
            }
        }



    }
}