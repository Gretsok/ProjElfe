using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeaponData : ScriptableObject
    {
        [System.Serializable]
        public class AWeaponSaveData
        {
            public string WeaponName;
            public Damage HitDamage;
            public float AttackSpeed;
            public AWeaponData WeaponData;
            public bool AllowContinueFiring;

            public AWeaponSaveData(AWeaponData weaponData)
            {
                WeaponName = weaponData.WeaponName;
                Random.InitState((new System.Random()).Next(0, 10000000));
                HitDamage = new Damage();
                HitDamage.HitDamage = Random.Range(weaponData.HitDamage.x, weaponData.HitDamage.y);
                HitDamage.DamageType = EDamageType.Physical;
                Random.InitState((new System.Random()).Next(0, 10000000));
                AttackSpeed = Random.Range(weaponData.AttackSpeed.x, weaponData.AttackSpeed.y);
                WeaponData = weaponData;
                AllowContinueFiring = weaponData.AllowContinueFiring;
            }
        }
        //Var
        [SerializeField] protected string m_weaponName = string.Empty;
        [SerializeField] protected Sprite m_weaponSprite = null;
        [SerializeField] protected Vector2Int m_hitDamage = default;
        [SerializeField] protected Vector2 m_attackSpeed = default;
        [SerializeField] protected AWeapon m_weaponPrefab = null;
        [SerializeField] protected bool m_allowContinueFiring = false;
        public bool AllowContinueFiring => m_allowContinueFiring;
        public Vector2 AttackSpeed => m_attackSpeed;
        public Vector2Int HitDamage => m_hitDamage;
        public string WeaponName => m_weaponName;
        public Sprite WeaponSprite => m_weaponSprite;


        public AWeapon WeaponPrefab => m_weaponPrefab;

        internal virtual T GetWeaponSaveData<T>() where T : AWeaponSaveData
        {
            AWeaponSaveData weaponSaveData = new AWeaponSaveData(this);

            return (T)weaponSaveData;
        }

    }
}

