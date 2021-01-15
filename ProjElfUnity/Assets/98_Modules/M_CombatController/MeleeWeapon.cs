﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    public class MeleeWeapon : AWeapon
    {
        public void InitMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData meleeWeaponData)
        {
            m_attackSpeed = meleeWeaponData.AttackSpeed;
            m_damage = new Damage();
            m_damage.HitDamage = meleeWeaponData.HitDamage;
            m_damage.DamageType = EDamageType.Physical;
            m_allowContinueFiring = meleeWeaponData.AllowContinueFiring;
            m_weaponName = meleeWeaponData.WeaponName;
            m_weaponSaveData = meleeWeaponData;
        }
    }
}


