using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Bow : AWeapon
    {
        //Var
        private float m_projectileRange;//À voir
        private float m_projectileDivingRate;
        private float m_projectileSpeed;
        [SerializeField] private Arrow m_projectilePrefab;
        [SerializeField] private Transform posArrow;
        private CombatController m_owner;

        public Transform PosArrow => posArrow;

        public void InitBow(BowData.BowSaveData bowToInit)
        {
            m_projectileRange = bowToInit.ProjectileRange;
            m_projectileDivingRate = bowToInit.ProjectileDivingRate;
            m_projectileSpeed = bowToInit.ProjectileSpeed;
            m_allowContinueFiring = bowToInit.AllowContinueFiring;
            m_attackSpeed = bowToInit.AttackSpeed;
            m_damage = Damage;
            m_weaponSaveData = bowToInit;
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
            newArrow.transform.LookAt(posArrow.position + direction);//Peut etre à changer (à mettre dans arrow ptetre) //Change la rotation de la fleche dans la direction visée
            newArrow.InitArrow(m_owner, m_projectileSpeed, m_projectileRange, m_projectileDivingRate, m_damage);
            return newArrow;
        }

        internal void BowAttack(Vector3 direction)
        {
            Arrow newArrow = InstantiateInitializedArrow(direction);
        }
    }
}

