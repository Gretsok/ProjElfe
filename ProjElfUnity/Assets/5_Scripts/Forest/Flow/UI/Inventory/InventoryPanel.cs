using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using ProjElf.CombatController;

namespace ProjElf.HubForest
{
    public class InventoryPanel : Panel
    {

        [SerializeField]
        private WeaponInfosPanel m_currentWeaponInfosPanel = null;
        [SerializeField]
        private WeaponInfosPanel m_selectedWeaponInfosPanel = null;

        [SerializeField]
        private CurrentWeaponSlot m_meleeWeaponSlot = null;
        [SerializeField]
        private CurrentWeaponSlot m_grimoireSlot = null;
        [SerializeField]
        private CurrentWeaponSlot m_bowSlot = null;
        private CurrentWeaponSlot m_selectedCurrentWeaponSlot = null;

        [SerializeField]
        private WeaponRenderTextureStudio m_renderTextureStudioPrefab = null;

        [SerializeField]
        private StockedWeaponSlot m_stockedWeaponSlotPrefab = null;
        [SerializeField]
        private FlexibleGrid m_stockedWeaponsGrid = null;
        private List<StockedWeaponSlot> m_stockedWeaponsSlots = new List<StockedWeaponSlot>();
        public List<StockedWeaponSlot> StockedWeaponSlots => m_stockedWeaponsSlots;

        [SerializeField]
        private TextMeshProUGUI m_moneyDisplayText = null;

        private MeleeWeaponData.MeleeWeaponSaveData m_equippedMeleeWeaponDisplayed = null;
        private BowData.BowSaveData m_equippedBowDisplayed = null;
        private GrimoireData.GrimoireSaveData m_equippedGrimoireDisplayed = null;



        #region Inflates

        public void InflateCurrentWeaponsData(MeleeWeaponData.MeleeWeaponSaveData currentMeleeWeaponSaveData,
            BowData.BowSaveData currentBowSaveData,
            GrimoireData.GrimoireSaveData currentGrimoireSaveData)
        {
            m_equippedMeleeWeaponDisplayed = currentMeleeWeaponSaveData;
            m_equippedBowDisplayed = currentBowSaveData;
            m_equippedGrimoireDisplayed = currentGrimoireSaveData;
        }

        public void InflateCurrentMeleeWeapon(MeleeWeaponData weaponData)
        {
            WeaponRenderTextureStudio renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(200, -1000, 200), Quaternion.identity);
            m_meleeWeaponSlot.Inflate(weaponData, renderStudio);
        }

        public void InflateCurrentGrimoire(GrimoireData grimoireData)
        {
            WeaponRenderTextureStudio renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(0, -1000, 200), Quaternion.identity);
            m_grimoireSlot.Inflate(grimoireData, renderStudio);
        }

        public void InflateCurrentBow(BowData bowData)
        {
            WeaponRenderTextureStudio renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(-200, -1000, 200), Quaternion.identity);
            m_bowSlot.Inflate(bowData, renderStudio);
        }

        public void InflateEarnedMeleeWeapons(List<MeleeWeaponData.MeleeWeaponSaveData> earnedWeapons)
        {
            for (int i = 0; i < earnedWeapons.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsGrid.transform);
                newStockedWeaponSlot.Inflate(earnedWeapons[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }
            m_stockedWeaponsGrid.UpdateGrid();

        }

        public void InflateEarnedBow(List<BowData.BowSaveData> earnedWeapons)
        {
            for (int i = 0; i < earnedWeapons.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsGrid.transform);
                newStockedWeaponSlot.Inflate(earnedWeapons[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }
            m_stockedWeaponsGrid.UpdateGrid();

        }

        public void InflateEarnedGrimoire(List<GrimoireData.GrimoireSaveData> earnedWeapons)
        {
            for (int i = 0; i < earnedWeapons.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsGrid.transform);
                newStockedWeaponSlot.Inflate(earnedWeapons[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }
            m_stockedWeaponsGrid.UpdateGrid();

        }

        public void InflateMoney(int moneyAmount)
        {
            m_moneyDisplayText.text = $"{moneyAmount} francissous";
        }
        #endregion


        public void ClearSlots()
        {
            m_meleeWeaponSlot.Clear();
            m_grimoireSlot.Clear();
            m_bowSlot.Clear();

            for (int i = m_stockedWeaponsSlots.Count - 1; i >= 0; --i)
            {
                var slot = m_stockedWeaponsSlots[i];
                m_stockedWeaponsSlots.RemoveAt(i);
                Destroy(slot.gameObject);

            }
        }

        public void SetSelectedWeaponSaveData(AWeaponData.AWeaponSaveData weaponSaveData)
        {
            Debug.Log("weapon selected");
            m_selectedCurrentWeaponSlot?.Unselect();
            if (weaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
            {
                m_selectedWeaponInfosPanel.InflateMeleeWeapon(weaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
                m_currentWeaponInfosPanel.InflateMeleeWeapon(m_equippedMeleeWeaponDisplayed);
                m_selectedCurrentWeaponSlot = m_meleeWeaponSlot;
            }
            else if(weaponSaveData is BowData.BowSaveData)
            {
                m_selectedWeaponInfosPanel.InflateBow(weaponSaveData as BowData.BowSaveData);
                m_currentWeaponInfosPanel.InflateBow(m_equippedBowDisplayed);
                m_selectedCurrentWeaponSlot = m_bowSlot;
            }
            else if(weaponSaveData is GrimoireData.GrimoireSaveData)
            {
                m_selectedWeaponInfosPanel.InflateGrimoire(weaponSaveData as GrimoireData.GrimoireSaveData);
                m_currentWeaponInfosPanel.InflateGrimoire(m_equippedGrimoireDisplayed);
                m_selectedCurrentWeaponSlot = m_grimoireSlot;
            }
            else
            {
                Debug.LogError("Incorrect weapon !");
            }
            m_selectedCurrentWeaponSlot?.Select();
        }


    }
}