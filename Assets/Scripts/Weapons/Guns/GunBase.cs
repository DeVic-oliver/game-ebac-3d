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


        private void Start()
        {
            _reloadTimeAux = _reloadTime;
            Debug.Log($"Reload Time Aux Received {_reloadTimeAux}");
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
            else
            {
                StartCoroutine(ReloadCoroutine());
            }

        }

        protected IEnumerator ReloadCoroutine()
        {
            while(_reloadTimeAux >= 0)
            {
                _reloadTimeAux -= Time.deltaTime;
                yield return new WaitForSeconds(.1f);
            }
            _currentMagazineAmount = _ammoMagazineCapacity;
            Debug.Log($"Gun fully reloaded: {_currentMagazineAmount} ammo in magazine");
        }
    }
}