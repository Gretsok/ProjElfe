using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "GrimoireData", menuName = "weaponData/GrimoireData")] //instancie un scripatble object
    public class GrimoireData : AWeaponData
    {
        //Var
        private float m_projectileSpeed;
        private float m_projectileRange;
        [SerializeField] private MagicSpellProjectile m_projectilePrefab;
        private bool m_allowContinueFiring;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

