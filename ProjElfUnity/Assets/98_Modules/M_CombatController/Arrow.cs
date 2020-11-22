using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Arrow : MonoBehaviour
    {
        //Var
        private float m_speed;
        private float m_fallSpeed;

        //Initialisateur
        public void InitArrow(float speed, float fallSpeed)
        {
            m_speed = speed;
            m_fallSpeed = fallSpeed;
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


