using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class CombatController : MonoBehaviour
    {
        //Var
        private CombatInventory m_combatInventory;
        private int m_lifePoints;
        private int m_maxLifePoints;
        private Action m_onLifeReachZero;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void UseWeapon()
        {

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

