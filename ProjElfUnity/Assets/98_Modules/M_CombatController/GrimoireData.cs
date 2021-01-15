using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "GrimoireData", menuName = "weaponData/GrimoireData")] //instancie un scripatble object
    public class GrimoireData : AWeaponData
    {
        //Var
        [SerializeField] private float m_projectileSpeed;
        [SerializeField] private float m_projectileLifeTime;
        [SerializeField] private MagicSpellProjectile m_projectilePrefab;
        
        public float ProjectileLifeTime => m_projectileLifeTime;
        
        public float ProjectileSpeed => m_projectileSpeed;

        public MagicSpellProjectile ProjectilePrefab => m_projectilePrefab;

        public float GetrefProjectileSpeed()
        {
            return refProjectileSpeed;
        }
        public bool GetrefAllowContinueFiring()
        {
            return refAllowContinueFiring;
        }

    }
}

