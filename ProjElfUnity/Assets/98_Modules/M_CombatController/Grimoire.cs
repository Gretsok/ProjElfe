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
        private bool m_allowContinueFiring;
        [SerializeField] private MagicSpellProjectile m_projectilePrefab;
        [SerializeField] private Transform posMagicSpell;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
        public void InitGrimoire(GrimoireData grimoireToInit)
        {
            m_projectileLifeTime = grimoireToInit.GetrefProjectileLifeTime();
            m_allowContinueFiring = grimoireToInit.GetrefAllowContinueFiring();
            m_projectileSpeed = grimoireToInit.GetrefProjectileSpeed();
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

        internal void GrimoireAttack(Vector3 direction)
        {
            MagicSpellProjectile newProjectile = InstantiateInitializedProjectile(direction);
        }
    }
}
