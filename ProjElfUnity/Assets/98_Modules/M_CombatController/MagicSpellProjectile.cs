using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class MagicSpellProjectile : MonoBehaviour
    {
        //Var
        private float m_speed;
        private float m_range;

        //Initialisateur
        public void InitMagicSpellProjectile(float speed,float range)
        {
            m_speed = speed;
            m_range = range;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


