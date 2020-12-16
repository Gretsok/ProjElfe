using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "BowData", menuName = "weaponData/BowData")]
    public class BowData : AWeaponData
    {
        //Var
        [SerializeField] private float m_projectileRange;
        [SerializeField] private float m_projectileDivingRate;
        [SerializeField] private float m_projectileSpeed;
        [SerializeField] private Arrow m_projectilePrefab;
        public float refProjectileRange => m_projectileRange;
        public float refProjectileDivingRate => m_projectileDivingRate;
        public float refProjectileSpeed => m_projectileSpeed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        //Getter
        public float GetrefProjectileRange()
        {
            return refProjectileRange;
        }
        public float GetrefProjectileDivingRate()
        {
            return refProjectileDivingRate;
        }
        public float GetrefProjectileSpeed()
        {
            return refProjectileSpeed;
        }
    }
}

