using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Weapons.Guns
{
    public abstract class GunBase : MonoBehaviour
    {
        [SerializeField] protected int _ammoMagazineCapacity;
        protected int _currentMagazineAmount;

        [SerializeField] protected float _reloadTime;
        private float _reloadTimeAux;

        [SerializeField] protected Transform _gunBarrel;
        [SerializeField] protected BulletBase _bulletType;

        protected bool _isReloading = false;

        protected void Start()
        {
            _reloadTimeAux = _reloadTime;
            _currentMagazineAmount = _ammoMagazineCapacity;
        }

        public virtual void Shoot()
        {
            if(MagazineHaveAmmo())
            {
                CreateBullet();
                DecreaseMagazineAmmo();
            }
            else if(!_isReloading)
            {
                _isReloading = true;
                StartCoroutine(ReloadCoroutine());
            }
        }
        public bool MagazineHaveAmmo()
        {
            if(_currentMagazineAmount > 0)
            {
                return true;
            }

            return false;
        }
        protected virtual void CreateBullet()
        {
            var bullet = Instantiate(_bulletType);
            bullet.transform.position = _gunBarrel.position;
            bullet.transform.rotation = _gunBarrel.rotation;
        }
        protected void DecreaseMagazineAmmo()
        {
            _currentMagazineAmount--;
        }
        protected void DecreaseMagazineAmmo(int quantityToDecrease)
        {
            _currentMagazineAmount -= quantityToDecrease;
        }
        protected IEnumerator ReloadCoroutine()
        {
            while(_reloadTimeAux >= 0)
            {
                _reloadTimeAux -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
            }

            ResetReloadAux();
            ReloadMagazine();
            _isReloading = false;
            Debug.Log($"Gun fully reloaded: {_currentMagazineAmount} ammo in magazine");
            yield break;
        }
        private void ResetReloadAux()
        {
            _reloadTimeAux = _reloadTime;
        }
        private void ReloadMagazine()
        {
            _currentMagazineAmount = _ammoMagazineCapacity;
        }
    }
}