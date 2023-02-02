using System.Collections;
using UnityEngine;
using Assets.Scripts.Core.Components.Weapon;

namespace Assets.Scripts.Core.Enemies
{
    [RequireComponent(typeof(RangedWeapon))]
    public abstract class RangedEnemy : EnemyBase
    {
    }
}