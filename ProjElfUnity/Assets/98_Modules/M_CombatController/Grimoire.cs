using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    public class Grimoire : AWeapon
    {
        //Var 
        private float m_projectileSpeed;
        private float m_projectileRange;
        private bool m_allowContinueFiring;
        [SerializeField] private MagicSpellProjectile m_projectilePrefab;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        MagicSpellProjectile InstantiateInitializedProjectile()
        {
            MagicSpellProjectile newProjectile;
            newProjectile = Instantiate<MagicSpellProjectile>(m_projectilePrefab, transform.position, transform.rotation);//Voir bow si jamais
            newProjectile.InitMagicSpellProjectile(m_projectileSpeed, m_projectileRange);
            return newProjectile;//pour pas avoir d'erreur /À enlever
        }
    }
}
