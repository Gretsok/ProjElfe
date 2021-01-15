using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Grimoire : AWeapon
    {
        //Var 
        private float m_projectileSpeed;
        private float m_projectileLifeTime;
        private MagicSpellProjectile m_projectilePrefab;
        [SerializeField] private Transform posMagicSpell;

        public void InitGrimoire(GrimoireData grimoireToInit)
        {
            m_projectileLifeTime = grimoireToInit.ProjectileLifeTime;
            m_allowContinueFiring = grimoireToInit.GetrefAllowContinueFiring();
            m_projectileSpeed = grimoireToInit.ProjectileSpeed;
            m_attackSpeed = grimoireToInit.AttackSpeed;
            m_projectilePrefab = grimoireToInit.ProjectilePrefab;
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
            newProjectile.InitMagicSpellProjectile(m_projectileSpeed, m_projectileLifeTime);
            return newProjectile;
        }

        internal void GrimoireAttack(Vector3 direction)//aspd du joueur à rajouter
        {
            MagicSpellProjectile newProjectile = InstantiateInitializedProjectile(direction);
        }
    }
}
