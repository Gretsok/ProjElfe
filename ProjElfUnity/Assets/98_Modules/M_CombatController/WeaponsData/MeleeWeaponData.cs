using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.CombatController
{
    [CreateAssetMenu(fileName = "MeleeWeaponData", menuName = "weaponData/MeleeWeaponData")]
    public class MeleeWeaponData : AWeaponData
    {
        [System.Serializable]
        public class MeleeWeaponSaveData : AWeaponSaveData
        {
            public MeleeWeaponSaveData(MeleeWeaponData meleeWeaponData) : base(meleeWeaponData)
            {
                s_weaponLabel = "meleeweapon";
            }

            public override void Unserialize()
            {
                s_weaponLabel = "meleeweapon";
                base.Unserialize();
            }

        }

        internal override T GetWeaponSaveData<T>()
        {
            MeleeWeaponSaveData meleeWeaponSaveData = new MeleeWeaponSaveData(this);

            return (meleeWeaponSaveData as T);
        }
    }
}

