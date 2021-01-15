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

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public bool GetrefAllowContinueFiring()
        {
            return refAllowContinueFiring;
        }

    }
}

