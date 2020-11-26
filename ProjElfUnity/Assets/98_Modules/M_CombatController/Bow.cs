using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Bow : AWeapon
    {
        //Var
        private float m_projectileRange;//À voir
        private float m_projectileFallSpeed;
        private float m_projectileSpeed;
        [SerializeField] private Arrow m_projectilePrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public Arrow InstantiateInitializedArrow()
        {
            Arrow newArrow;
            newArrow = Instantiate<Arrow>(m_projectilePrefab, transform.position, transform.rotation);//instancie dans la scene du bow | transform = "position" du bow mais enfant
            newArrow.InitArrow(m_projectileSpeed, m_projectileFallSpeed);
            return newArrow;//pour pas avoir d'erreur /À enlever
        }

        internal void FireArrow()
        {
            Arrow newArrow = InstantiateInitializedArrow();
        }
    }
}

