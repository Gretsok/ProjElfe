using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    [System.Serializable]
    public class Damage
    {
        [SerializeField]
        internal int HitDamage;
        [SerializeField]
        internal EDamageType DamageType;
    }
}
