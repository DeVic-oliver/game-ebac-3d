using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Enemies;
using Assets.Scripts.Core.Interfaces;

namespace Assets.Scripts.Enemies.Blob
{
    public class RangedBlobBoss : RangedEnemy, IMoveable, IDamageable
    {
        public void Move(bool isAlive)
        {
            throw new System.NotImplementedException();
        }

        public void TakeDamage(int damageValue)
        {
            throw new System.NotImplementedException();
        }

        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

    }
}