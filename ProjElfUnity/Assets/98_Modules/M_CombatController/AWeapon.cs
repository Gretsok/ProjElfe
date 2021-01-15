using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public abstract class AWeapon : MonoBehaviour
    {
        //Var
        protected string m_weaponName;
        protected Damage m_damage;
        protected float m_attackSpeed;
        protected bool m_allowContinueFiring;
        public bool AllowContinueFiring => m_allowContinueFiring;// c un get
        public float AttackSpeed => m_attackSpeed;//c ossi un get

        //private CombatController m_owner;

        public Damage Damage => m_damage;


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

