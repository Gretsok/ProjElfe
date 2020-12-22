using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class MagicSpellProjectile : MonoBehaviour
    {
        //Var
        private float m_speed;
        private float m_lifeTime;
        private float m_actualLifeTime;

        //Initialisateur
        public void InitMagicSpellProjectile(float speed,float range)
        {
            m_speed = speed;
            m_lifeTime = range;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position += this.transform.forward * Time.deltaTime * m_speed;
            m_actualLifeTime++;
            //Gerer destroy
            if (m_actualLifeTime >= m_lifeTime)
            {
                Destroy(this.gameObject);
            }
        }
    }
}


