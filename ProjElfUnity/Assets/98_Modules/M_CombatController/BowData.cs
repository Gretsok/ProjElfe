using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "BowData", menuName = "weaponData/BowData")]
    public class BowData : AWeaponData
    {
        //Var
        [SerializeField] private float m_projectileRange;
        [SerializeField] private float m_projectileFallSpeed;
        [SerializeField] private float m_projectileSpeed;
        [SerializeField] private Arrow m_projectilePrefab;

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

