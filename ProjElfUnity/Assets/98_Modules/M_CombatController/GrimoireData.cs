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
        [SerializeField] private bool m_allowContinueFiring;

        public float refProjectileLifeTime => m_projectileLifeTime;
        public bool refAllowContinueFiring => m_allowContinueFiring;
        public float refProjectileSpeed => m_projectileSpeed;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public float GetrefProjectileSpeed()
        {
            return refProjectileSpeed;
        }
        public bool GetrefAllowContinueFiring()
        {
            return refAllowContinueFiring;
        }
        public float GetrefProjectileLifeTime()
        {
            return refProjectileLifeTime;
        }
    }
}

