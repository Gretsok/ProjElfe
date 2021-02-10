using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    public class MeleeWeapon : AWeapon, IDamageGiver
    {
        private CombatController m_owner = null;

        public CombatController Owner => m_owner;

        public float Cooldown => 1 / m_attackSpeed;

        public void InitMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData meleeWeaponData, CombatController Owner)
        {
            m_attackSpeed = meleeWeaponData.AttackSpeed;
            m_damage = meleeWeaponData.HitDamage;
            m_allowContinueFiring = meleeWeaponData.AllowContinueFiring;
            m_weaponName = meleeWeaponData.WeaponName;
            m_weaponSaveData = meleeWeaponData;
            m_owner = Owner;
        }

        public void OnCombatControllerHit(CombatController hitController)
        {
            
        }
    }
}


