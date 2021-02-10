using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Grimoire : AWeapon
    {
        //Var 
        private float m_projectileSpeed = 0f;
        private float m_projectileLifeTime = 0f;
        private MagicSpellProjectile m_projectilePrefab = null;
        private CombatController m_owner = null;
        [SerializeField] private Transform posMagicSpell = null;

        public Transform PosMagicSpell => posMagicSpell;
        public void InitGrimoire(GrimoireData.GrimoireSaveData grimoireToInit, CombatController Owner)
        {
            m_projectileLifeTime = grimoireToInit.ProjectileLifeTime;
            m_allowContinueFiring = grimoireToInit.AllowContinueFiring;
            m_projectileSpeed = grimoireToInit.ProjectileSpeed;
            m_attackSpeed = grimoireToInit.AttackSpeed;
            m_projectilePrefab = grimoireToInit.ProjectilePrefab;
            m_weaponSaveData = grimoireToInit;
            m_damage = grimoireToInit.HitDamage;
            m_owner = Owner;
        }
        /// <summary>
        /// Instantie un MagicSpellProjectile qui ira vers la direction ciblée
        /// </summary>
        /// <param name="direction"></param>
        /// <returns></returns>
        MagicSpellProjectile InstantiateInitializedProjectile(Vector3 direction)//A transformer en void
        {
            MagicSpellProjectile newProjectile;
            newProjectile = Instantiate<MagicSpellProjectile>(m_projectilePrefab, posMagicSpell.position, posMagicSpell.rotation);//Voir bow si jamais
            newProjectile.transform.LookAt(posMagicSpell.position + direction);
            newProjectile.InitMagicSpellProjectile(m_owner, m_projectileSpeed, m_projectileLifeTime, m_damage);
            return newProjectile;
        }

        internal void GrimoireAttack(Vector3 direction)//aspd du joueur à rajouter
        {
            MagicSpellProjectile newProjectile = InstantiateInitializedProjectile(direction);
        }
    }
}
