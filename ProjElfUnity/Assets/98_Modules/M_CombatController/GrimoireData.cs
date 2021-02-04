using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "GrimoireData", menuName = "weaponData/GrimoireData")] //instancie un scripatble object
    public class GrimoireData : AWeaponData
    {
        [System.Serializable]
        public class GrimoireSaveData : AWeaponSaveData
        {
            public float ProjectileSpeed;
            public float ProjectileLifeTime;
            [SerializeField]
            public MagicSpellProjectile ProjectilePrefab;

            public GrimoireSaveData(GrimoireData grimoireData) : base(grimoireData)
            {
                Random.InitState((new System.Random()).Next(0, 10000000));
                ProjectileSpeed = Random.Range(grimoireData.ProjectileSpeed.x, grimoireData.ProjectileSpeed.y);
                HitDamage.DamageType = EDamageType.Magical;
                Random.InitState((new System.Random()).Next(0, 10000000));
                ProjectileLifeTime = Random.Range(grimoireData.ProjectileLifeTime.x, grimoireData.ProjectileLifeTime.y);
                ProjectilePrefab = grimoireData.ProjectilePrefab;
            }
        }

        //Var
        [SerializeField] private Vector2 m_projectileSpeed;
        [SerializeField] private Vector2 m_projectileLifeTime;
        [SerializeField] private MagicSpellProjectile m_projectilePrefab;
        
        public Vector2 ProjectileLifeTime => m_projectileLifeTime;
        public Vector2 ProjectileSpeed => m_projectileSpeed;
        public MagicSpellProjectile ProjectilePrefab => m_projectilePrefab;

        internal override T GetWeaponSaveData<T>()
        {
            GrimoireSaveData grimoireSaveData = new GrimoireSaveData(this);

            return (grimoireSaveData as T);
        }
    }
}

