using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatController : MonoBehaviour
    {
        //Var
        [SerializeField] private CombatInventory m_combatInventory;
        private int m_lifePoints;
        private int m_maxLifePoints;
        private Action m_onLifeReachZero;

        private AWeapon m_usedWeapon;

        private bool m_isShooting;
        private float m_timeLastShoot = float.MinValue;

        [SerializeField] private CharacterAnimatorHandler m_characterAnimatorHandler;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void DoUpdate(Vector3 direction = default(Vector3))//appelé depuis le player ou l'ia pour maj combatcontroller
        {
            if (m_isShooting && m_usedWeapon.AllowContinueFiring && (Time.time-m_timeLastShoot > (1/m_usedWeapon.AttackSpeed)))
            {
                if (m_usedWeapon is MeleeWeapon)
                {
                    m_combatInventory.UseMeleeWeapon();
                    m_characterAnimatorHandler.AttackWithSword();
                }
                else if (m_usedWeapon is Grimoire)
                {
                    m_combatInventory.UseGrimoireWeapon(direction);
                }
                else if (m_usedWeapon is Bow)
                {
                    m_combatInventory.UseBowWeapon(direction);
                }
                m_timeLastShoot = Time.time;
            }
        }

        /// <summary>
        /// Récupère l'arme équipée
        /// </summary>
        public void GetUsedWeapon()
        {
            m_usedWeapon = m_combatInventory.GetUsedWeapon();
        }

        public void ChangeWeapon(AWeaponData newWeaponData)
        {
            if(newWeaponData is MeleeWeaponData)
            {
                m_combatInventory.ChangeMeleeWeapon((MeleeWeaponData)newWeaponData);
            }
            else if(newWeaponData is GrimoireData)
            {
                m_combatInventory.ChangeGrimoire((GrimoireData)newWeaponData);
            }
            else if(newWeaponData is BowData)
            {
                m_combatInventory.ChangeBow((BowData)newWeaponData);
            }
        }

        public void SelectNextWeapon()
        {
            m_combatInventory.SelectNextWeapon();
            GetUsedWeapon();
        }

        public void SelectPreviousWeapon()
        {
            m_combatInventory.SelectPreviousWeapon();
            GetUsedWeapon();
        }

        public void StartUseWeapon(Vector3 direction = default(Vector3)) //default(Vector3) car argument optionnel
        {
            m_isShooting = true;
            if (Time.time - m_timeLastShoot > (1 / m_usedWeapon.AttackSpeed))
            {
                if (m_usedWeapon is MeleeWeapon)
                {
                    m_combatInventory.UseMeleeWeapon();
                }
                else if (m_usedWeapon is Grimoire)
                {
                    m_combatInventory.UseGrimoireWeapon(direction);
                }
                else if (m_usedWeapon is Bow)
                {
                    m_combatInventory.UseBowWeapon(direction);
                }
                m_timeLastShoot = Time.time;
            }
        }

        public void StopUseWeapon()
        {
            m_isShooting = false;
        }

        public void TakeDamage(int damage)
        {
            m_lifePoints -= damage;
            if(m_lifePoints<=0)
            {
                m_onLifeReachZero?.Invoke();//Lance l'action si pas null
            }
        }
    }
}

