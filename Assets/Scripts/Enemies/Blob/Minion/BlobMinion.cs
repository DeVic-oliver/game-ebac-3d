using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Enemies;

namespace Assets.Scripts.Enemies.Blob
{

    public class BlobMinion : EnemyBase
    {
        [SerializeField] private ParticleSystem _deathVfx;

        new void Start()
        {
            base.Start();
        }

        new void Update()
        {
            base.Update();
        }

        public void PlayDeathVFX()
        {
            _deathVfx.Play();
        }
    }
}

