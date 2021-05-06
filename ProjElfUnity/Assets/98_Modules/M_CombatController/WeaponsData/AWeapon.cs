using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeapon : MonoBehaviour
    {
        //Var
        protected string m_weaponName;
        protected Damage m_damage;
        protected float m_attackSpeed;
        protected bool m_allowContinueFiring;
        protected AWeaponData.AWeaponSaveData m_weaponSaveData = null;
        public bool AllowContinueFiring => m_allowContinueFiring;// c un get
        public float AttackSpeed => m_attackSpeed;//c ossi un get
        public AWeaponData.AWeaponSaveData WeaponSaveData => m_weaponSaveData;

        //private CombatController m_owner;

        public Damage Damage => m_damage;

        internal virtual void OnEquipped()
        {

        }

        internal virtual void OnUnequipped()
        {

        }

    }
}

