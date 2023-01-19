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

        private bool _isReloading = false;

        protected void Start()
        {
            _reloadTimeAux = _reloadTime;
            _currentMagazineAmount = _ammoMagazineCapacity;
        }

        public virtual void Shoot()
        {
            if(_currentMagazineAmount > 0)
            {
                var bullet = Instantiate(_bulletType);
                bullet.transform.position = _gunBarrel.position;
                bullet.transform.rotation = _gunBarrel.rotation;
                _currentMagazineAmount--;
            }
            else if(!_isReloading)
            {
                _isReloading = true;
                StartCoroutine(ReloadCoroutine());
            }

        }

        protected IEnumerator ReloadCoroutine()
        {
            while(_reloadTimeAux >= 0)
            {
                _reloadTimeAux -= Time.deltaTime;
                yield return new WaitForEndOfFrame();
                Debug.Log(_reloadTimeAux);
            }

            _reloadTimeAux = _reloadTime;
            _currentMagazineAmount = _ammoMagazineCapacity;
            _isReloading = false;
            Debug.Log($"Gun fully reloaded: {_currentMagazineAmount} ammo in magazine");
            StopCoroutine(ReloadCoroutine());
        }
    }
}