using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    public class MeleeWeapon : AWeapon
    {
        private CombatController m_owner = null;

        public void InitMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData meleeWeaponData, CombatController Owner)
        {
            m_attackSpeed = meleeWeaponData.AttackSpeed;
            m_damage = meleeWeaponData.HitDamage;
            m_allowContinueFiring = meleeWeaponData.AllowContinueFiring;
            m_weaponName = meleeWeaponData.WeaponName;
            m_weaponSaveData = meleeWeaponData;
            m_owner = Owner;
        }
    }
}


