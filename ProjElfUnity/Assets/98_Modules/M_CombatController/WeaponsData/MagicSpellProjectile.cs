using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class MagicSpellProjectile : MonoBehaviour, IDamageGiver
    {
        //Var
        private float m_speed;
        private float m_lifeTime;
        private float m_actualLifeTime;
        private Damage m_damage;
        public Damage Damage => m_damage;

        public CombatController Owner { get; private set; }

        public float Cooldown => 10f;

        public bool CanDoDamage => true;

        //Initialisateur
        public void InitMagicSpellProjectile(CombatController owner, float speed, float range, Damage damage)
        {
            Owner = owner;
            m_speed = speed;
            m_lifeTime = range;
            m_damage = damage;
        }

        public void OnCombatControllerHit(CombatController hitController)
        {
            Destroy(gameObject);
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            this.transform.position += this.transform.forward * Time.fixedDeltaTime * m_speed;
            m_actualLifeTime += Time.fixedDeltaTime;
            //Gerer destroy
            if (m_actualLifeTime >= m_lifeTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}


