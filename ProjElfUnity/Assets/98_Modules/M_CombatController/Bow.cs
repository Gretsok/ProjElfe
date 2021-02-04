using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Bow : AWeapon
    {
        //Var
        private float m_projectileDivingRate = 0;
        private float m_projectileSpeed = 0;
        [SerializeField] private Arrow m_projectilePrefab = null;
        [SerializeField] private Transform posArrow = null;
        private CombatController m_owner = null;

        public Transform PosArrow => posArrow;
        
        public void InitBow(BowData.BowSaveData bowToInit, CombatController Owner)
        {
            m_projectileDivingRate = bowToInit.ProjectileDivingRate;
            m_projectileSpeed = bowToInit.ProjectileSpeed;
            m_allowContinueFiring = bowToInit.AllowContinueFiring;
            m_attackSpeed = bowToInit.AttackSpeed;
            m_damage = bowToInit.HitDamage;
            m_weaponSaveData = bowToInit;
            m_owner = Owner;
        }
        /// <summary>
        /// Instantie une arrow qui ira vers la direction ciblée
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        public Arrow InstantiateInitializedArrow(Vector3 direction)//A transformer en void
        {
            Arrow newArrow;
            newArrow = Instantiate<Arrow>(m_projectilePrefab, posArrow.position, Quaternion.identity);//instancie dans la scene du bow | transform = "position" du bow mais enfant
            newArrow.InitArrow(m_owner, m_projectileSpeed * direction.normalized, m_projectileDivingRate, m_damage);
            return newArrow;
        }

        internal void BowAttack(Vector3 direction)
        {
            Arrow newArrow = InstantiateInitializedArrow(direction);
        }
    }
}

