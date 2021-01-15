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
        [SerializeField] private int m_attackSpeed;
        [SerializeField] private AWeapon m_weaponPrefab;
        [SerializeField] private bool m_allowContinueFiring;
        public bool refAllowContinueFiring => m_allowContinueFiring;
        public float AttackSpeed => m_attackSpeed;
        public int HitDamage => m_hitDamage;
        public string WeaponName => m_weaponName;


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

