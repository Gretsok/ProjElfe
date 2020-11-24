using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeaponData : ScriptableObject
    {
        //Var
        [SerializeField] private string m_weaponName;
        [SerializeField] private int m_hitDamage;
        [SerializeField] private float m_attackSpeed;
        [SerializeField] private AWeapon m_weaponPrefab;
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

