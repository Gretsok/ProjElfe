using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Arrow : MonoBehaviour, IDamageGiver
    {
        //Var
        private float m_speed;
        private float m_range; //à implémenter
        private float m_divingRate;
        private Damage m_damage;
        private float m_lifeTime; //à implémenter

        public CombatController Owner { get; private set; }

        public Damage Damage => m_damage;
        public float Cooldown => 5f;

        public void OnCombatControllerHit(CombatController hitController)
        {
            Destroy(gameObject);
        }

        //Initialisateur
        public void InitArrow(CombatController owner, float speed, float range, float divingRate, Damage damage)
        {
            Owner = owner;
            m_speed = speed;
            m_range = range;
            m_divingRate = divingRate;
            m_damage = damage;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            this.transform.position += this.transform.forward * Time.fixedDeltaTime * m_speed;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.down, m_divingRate * Time.fixedDeltaTime);
        }

    }
}


