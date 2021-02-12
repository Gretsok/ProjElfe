using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Arrow : MonoBehaviour, IDamageGiver, IndependantObject.IndependantObject, ObjectPool.IPoolable
    {
        //Var
        private Vector3 m_initialVelocity;
        private Vector3 m_initialPosition;
        private float m_gravityApplied;
        private Damage m_damage;
        private float m_lifeTime = 10f; //à implémenter

        public CombatController Owner { get; private set; }

        public Damage Damage => m_damage;
        public float Cooldown => 0.1f;

        private bool m_isPoolable = true;
        public bool IsPoolable => m_isPoolable;

        public bool CanDoDamage => true;

        private bool m_isAlive = false;
        #region TimeManagement
        private float m_timePassed = 0f;
        #endregion

        public void OnCombatControllerHit(CombatController hitController)
        {
            Debug.Log(hitController.gameObject.name);
            DestroyArrow();
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
            IndependantObject.IndependantObjectManager.Instance.RegisterNewIndependantObject(this);
            m_isPoolable = false;
            gameObject.SetActive(true);
            m_isAlive = true;
        }

        public Vector3 CalculateArrowPosition(float time)
        {
            Vector3 pos = Vector2.zero;

            pos.x = m_initialPosition.x + m_initialVelocity.x * time;
            pos.z = m_initialPosition.z + m_initialVelocity.z * time;
            pos.y = m_initialPosition.y + (m_initialVelocity.y * time) - (m_gravityApplied * (time * time) / 2);

            return pos;
        }

        private void DestroyArrow()
        {
            gameObject.SetActive(false);
            m_isPoolable = true;
            m_isAlive = false;
            IndependantObject.IndependantObjectManager.Instance.UnregisterIndependantObject(this);
        }

        public void DoUpdate()
        {
            
        }

        public void DoFixedUpdate()
        {
            if(m_isAlive)
            {
                if (m_timePassed < m_lifeTime)
                {
                    Vector3 newPosition = CalculateArrowPosition(m_timePassed);
                    transform.LookAt(newPosition);
                    transform.position = newPosition;
                    m_timePassed += Time.fixedDeltaTime;
                }
                else
                {
                    DestroyArrow();
                }
            }
        }

        public void DoLateUpdate()
        {
            
        }

        private void OnCollisionEnter(Collision collision)
        {
            DestroyArrow();
        }
    }
}