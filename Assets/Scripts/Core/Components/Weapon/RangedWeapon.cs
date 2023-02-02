using System.Collections;
using UnityEngine;

namespace Assets.Scripts.Core.Components.Weapon
{
    using Assets.Scripts.Core.Components.Projectile;
    
    public class RangedWeapon : MonoBehaviour
    {
        [Header("Weapon Setup")]
        [SerializeField] protected Transform _weaponPosition;
        [SerializeField] protected Projectile _projectile;
        [SerializeField] protected float _intervalBetweenShoots;


        // Use this for initialization
        void Start()
        {
                StartCoroutine(ShootProjectile());
        }
        

        // Update is called once per frame
        void Update()
        {
        }
        IEnumerator ShootProjectile()
        {
            int shootsMade = 0;

            while (shootsMade <= 3)
            {
                shootsMade++;
                ShootProjectileFromWeaponPosition();
                yield return new WaitForSeconds(_intervalBetweenShoots);
            }
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