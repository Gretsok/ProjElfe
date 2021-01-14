using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Arrow : MonoBehaviour
    {
        //Var
        private float m_speed;
        private float m_divingRate;

        //Initialisateur
        public void InitArrow(float speed, float divingRate)
        {
            m_speed = speed;
            m_divingRate = divingRate;
        }

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            this.transform.position += this.transform.forward * Time.deltaTime * m_speed;
            transform.forward = Vector3.Lerp(transform.forward, Vector3.down, m_divingRate * Time.deltaTime);
        }
    }
}


