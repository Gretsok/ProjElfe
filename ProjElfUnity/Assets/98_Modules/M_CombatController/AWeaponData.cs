using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeaponData : ScriptableObject
    {
        //Var
        private string m_weaponName;
        private int m_hitDamage;
        private float m_attackSpeed;
        private AWeapon m_weaponPrefab;
        public AWeapon WeaponPrefab => m_weaponPrefab;

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

