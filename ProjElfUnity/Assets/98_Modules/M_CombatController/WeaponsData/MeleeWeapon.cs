using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.CombatController
{
    public class MeleeWeapon : AWeapon, IDamageGiver
    {
        private CombatController m_owner = null;

        public CombatController Owner => m_owner;

        public float Cooldown => 0.1f;

        private bool m_canDoDamage = false;
        public bool CanDoDamage => m_canDoDamage;

        public Action<IDamageGiver> OnDisappear { get; set; } = null;


        [SerializeField]
        private ParticleSystem m_weaponTrailFX = null;

        public void InitMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData meleeWeaponData, CombatController Owner)
        {
            m_attackSpeed = meleeWeaponData.AttackSpeed;
            m_damage = meleeWeaponData.HitDamage;
            m_allowContinueFiring = meleeWeaponData.AllowContinueFiring;
            m_weaponName = meleeWeaponData.WeaponName;
            m_weaponSaveData = meleeWeaponData;
            m_owner = Owner;
            StopDamaging();
        }

        public void StartDamaging()
        {
            if(m_weaponTrailFX != null)
            {
                m_weaponTrailFX.Play();
            }
            m_canDoDamage = true;
        }

        public void StopDamaging()
        {
            if (m_weaponTrailFX != null)
            {
                m_weaponTrailFX.Stop();
            }
            m_canDoDamage = false;
        }

        public void OnCombatControllerHit(CombatController hitController)
        {
            
        }

        private void OnDestroy()
        {
            OnDisappear?.Invoke(this);
        }
    }
}


