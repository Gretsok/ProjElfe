using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Arrow : MonoBehaviour, IDamageGiver
    {
        //Var
        private Vector3 m_initialVelocity;
        private Vector3 m_initialPosition;
        private float m_gravityApplied;
        private Damage m_damage;
        private float m_lifeTime; //à implémenter

        public CombatController Owner { get; private set; }

        public Damage Damage => m_damage;
        public float Cooldown => 5f;

        #region TimeManagement
        private float m_timePassed = 0f;
        #endregion

        public void OnCombatControllerHit(CombatController hitController)
        {
            Destroy(gameObject);
        }

        //Initialisateur
        public void InitArrow(CombatController owner, Vector3 initialVelocity, float gravityApplied, Damage damage)
        {
            Owner = owner;
            m_initialVelocity = initialVelocity;
            m_gravityApplied = gravityApplied;
            m_damage = damage;
            m_initialPosition = transform.position;
            m_timePassed = 0f;
        }

        public Vector3 CalculateArrowPosition(float time)
        {
            Vector3 pos = Vector2.zero;

            pos.x = m_initialPosition.x + m_initialVelocity.x * time;
            pos.z = m_initialPosition.z + m_initialVelocity.z * time;
            pos.y = m_initialPosition.y + (m_initialVelocity.y * time) - (m_gravityApplied * (time * time) / 2);

            return pos;
        }

        // Update is called once per frame
        void FixedUpdate()
        {
            Vector3 newPosition = CalculateArrowPosition(m_timePassed);
            transform.LookAt(newPosition);
            transform.position = newPosition;
            m_timePassed += Time.fixedDeltaTime;
        }

    }
}


