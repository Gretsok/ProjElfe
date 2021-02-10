using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "BowData", menuName = "weaponData/BowData")]
    public class BowData : AWeaponData
    {
        [System.Serializable]
        public class BowSaveData : AWeaponSaveData
        {
            public float ProjectileDivingRate;
            public float ProjectileSpeed;
            [SerializeField]
            public Arrow ProjectilePrefab;

            public BowSaveData(BowData bowData) : base(bowData)
            {

                Random.InitState((new System.Random()).Next(0, 10000000));
                ProjectileDivingRate = Random.Range(bowData.ProjectileDivingRate.x, bowData.ProjectileDivingRate.y);
                Random.InitState((new System.Random()).Next(0, 10000000));
                ProjectileSpeed = Random.Range(bowData.ProjectileSpeed.x, bowData.ProjectileSpeed.y);
                ProjectilePrefab = bowData.ProjectilePrefab;
            }
        }
        //Var
        [SerializeField] private Vector2 m_projectileDivingRate = Vector2.zero;
        [SerializeField] private Vector2 m_projectileSpeed = Vector2.zero;
        [SerializeField] private Arrow m_projectilePrefab = null;
        public Vector2 ProjectileDivingRate => m_projectileDivingRate;
        public Vector2 ProjectileSpeed => m_projectileSpeed;
        public Arrow ProjectilePrefab => m_projectilePrefab;

        internal override T GetWeaponSaveData<T>()
        {
            BowSaveData bowSaveData = new BowSaveData(this);

            return (bowSaveData as T);
        }
    }
}

