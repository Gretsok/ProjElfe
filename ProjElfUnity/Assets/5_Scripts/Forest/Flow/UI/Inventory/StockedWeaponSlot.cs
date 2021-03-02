using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static ProjElf.CombatController.AWeaponData;

namespace ProjElf.HubForest
{
    public class StockedWeaponSlot : MonoBehaviour
    {
        private AWeaponSaveData m_weaponSaveData = null;

        [SerializeField]
        private Image m_weaponIconImage = null;

        public void Inflate(AWeaponSaveData weaponSaveData)
        {
            m_weaponSaveData = weaponSaveData;
            m_weaponIconImage.sprite = m_weaponSaveData.WeaponData.WeaponSprite;
        }
    }
}