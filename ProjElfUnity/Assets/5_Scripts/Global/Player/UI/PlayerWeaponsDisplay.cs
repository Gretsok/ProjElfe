using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.PlayerController
{
    public class PlayerWeaponsDisplay : MonoBehaviour
    {
        [SerializeField]
        private Image m_lastWeaponImage = null;
        [SerializeField]
        private Image m_currentWeaponImage = null;
        [SerializeField]
        private Image m_nextWeaponImage = null;

        private BowData.BowSaveData m_bowSaveData = null;
        private GrimoireData.GrimoireSaveData m_grimoireSaveData = null;
        private MeleeWeaponData.MeleeWeaponSaveData m_meleeWeaponSaveData = null;

        private void Awake()
        {
            SetNoWeaponActive();
        }

        public void InflateBow(BowData.BowSaveData bowSaveData)
        {
            m_bowSaveData = bowSaveData;
        }

        public void InflateGrimoire(GrimoireData.GrimoireSaveData grimoireSaveData)
        {
            m_grimoireSaveData = grimoireSaveData;
        }

        public void InflateMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData meleeSaveData)
        {
            m_meleeWeaponSaveData = meleeSaveData;
        }
        public void SetBowActive()
        {
            gameObject.SetActive(true);
            m_lastWeaponImage.sprite = m_meleeWeaponSaveData.WeaponData.WeaponSprite;
            m_currentWeaponImage.sprite = m_bowSaveData.WeaponData.WeaponSprite;
            m_nextWeaponImage.sprite = m_grimoireSaveData.WeaponData.WeaponSprite;
        }

        public void SetGrimoireActive()
        {
            gameObject.SetActive(true);
            m_lastWeaponImage.sprite = m_bowSaveData.WeaponData.WeaponSprite;
            m_currentWeaponImage.sprite = m_grimoireSaveData.WeaponData.WeaponSprite;
            m_nextWeaponImage.sprite = m_meleeWeaponSaveData.WeaponData.WeaponSprite;
        }

        public void SetMeleeWeaponActive()
        {
            gameObject.SetActive(true);
            m_lastWeaponImage.sprite = m_grimoireSaveData.WeaponData.WeaponSprite;
            m_currentWeaponImage.sprite = m_meleeWeaponSaveData.WeaponData.WeaponSprite;
            m_nextWeaponImage.sprite = m_bowSaveData.WeaponData.WeaponSprite;
        }

        public void SetNoWeaponActive()
        {
            gameObject.SetActive(false);
        }
    }
}