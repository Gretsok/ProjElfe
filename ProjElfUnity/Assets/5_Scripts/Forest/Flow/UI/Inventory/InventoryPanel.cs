using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using static ProjElf.CombatController.AWeaponData;
using static ProjElf.CombatController.BowData;
using static ProjElf.CombatController.GrimoireData;
using static ProjElf.CombatController.MeleeWeaponData;

namespace ProjElf.HubForest
{
    public class InventoryPanel : Panel
    {
        private bool m_isLoaded = false;
        private HubForestGameMode m_gamemode = null;
        private SaveData m_currentSaveData = null;

        [SerializeField]
        private InventoryChest m_inventoryChest = null;

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

        [SerializeField]
        private WeaponRenderTextureStudio m_renderTextureStudioPrefab = null;

        [SerializeField]
        private StockedWeaponSlot m_stockedWeaponSlotPrefab = null;
        [SerializeField]
        private Transform m_stockedWeaponsContainer = null;
        private List<StockedWeaponSlot> m_stockedWeaponsSlots = new List<StockedWeaponSlot>();

        public override void Show()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
            m_gamemode.Player.MakeBusy(m_inventoryChest.transform);
            base.Show();

            m_gamemode.Actions.Enable();
            m_gamemode.Actions.UI.Back.performed += Back_performed;
            StartCoroutine(LoadInventoryPanelRoutine());

            
        }

        IEnumerator LoadInventoryPanelRoutine()
        {
            m_currentSaveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();

            WeaponRenderTextureStudio renderStudio;
            if (m_gamemode.Player.CombatController.CombatInventory.MeleeWeapon != null)
            {
                renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(200, -1000, 200), Quaternion.identity);
                m_meleeWeaponSlot.Inflate(m_gamemode.Player.CombatController.CombatInventory.MeleeWeapon.WeaponSaveData.WeaponData, renderStudio);
                yield return null;
            }
            if (m_gamemode.Player.CombatController.CombatInventory.Grimoire != null)
            {
                renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(0, -1000, 200), Quaternion.identity);
                m_grimoireSlot.Inflate(m_gamemode.Player.CombatController.CombatInventory.Grimoire.WeaponSaveData.WeaponData, renderStudio);
                yield return null;
            }
            if (m_gamemode.Player.CombatController.CombatInventory.Bow != null)
            {
                renderStudio = Instantiate<WeaponRenderTextureStudio>(m_renderTextureStudioPrefab, new Vector3(-200, -1000, 200), Quaternion.identity);
                m_bowSlot.Inflate(m_gamemode.Player.CombatController.CombatInventory.Bow.WeaponSaveData.WeaponData, renderStudio);
                yield return null;
            }


            for(int i = 0; i < m_currentSaveData.EarnedMeleeWeapons.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsContainer);
                newStockedWeaponSlot.Inflate(m_currentSaveData.EarnedMeleeWeapons[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }

            for (int i = 0; i < m_currentSaveData.EarnedGrimoires.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsContainer);
                newStockedWeaponSlot.Inflate(m_currentSaveData.EarnedGrimoires[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }

            for (int i = 0; i < m_currentSaveData.EarnedBows.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsContainer);
                newStockedWeaponSlot.Inflate(m_currentSaveData.EarnedBows[i], this);
                m_stockedWeaponsSlots.Add(newStockedWeaponSlot);
            }

            yield return null;

            m_isLoaded = true;
            EventSystem.current.SetSelectedGameObject(m_meleeWeaponSlot.gameObject);
        }

        IEnumerator UnloadInventoryPanelRoutine()
        {
            m_meleeWeaponSlot.Clear();
            m_grimoireSlot.Clear();
            m_bowSlot.Clear();
            yield return null;

            for(int i = m_stockedWeaponsSlots.Count - 1; i >= 0; --i)
            {
                var slot = m_stockedWeaponsSlots[i];
                m_stockedWeaponsSlots.RemoveAt(i);
                Destroy(slot.gameObject);
                
            }


            yield return null;
            m_isLoaded = false;
            QuitPanel();
        }

        private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_isLoaded)
            {
                StartCoroutine(UnloadInventoryPanelRoutine());
            }
        }

        public void SetSelectedWeaponSaveData(AWeaponSaveData weaponSaveData)
        {
            Debug.Log("weapon selected");
            if (weaponSaveData is MeleeWeaponSaveData)
            {
                m_selectedWeaponInfosPanel.InflateMeleeWeapon(weaponSaveData as MeleeWeaponSaveData);
                m_currentWeaponInfosPanel.InflateMeleeWeapon(m_currentSaveData.SavedPlayerWeaponInventory.EquippedMeleeWeapon);
            }
            else if(weaponSaveData is BowSaveData)
            {
                m_selectedWeaponInfosPanel.InflateBow(weaponSaveData as BowSaveData);
                m_currentWeaponInfosPanel.InflateBow(m_currentSaveData.SavedPlayerWeaponInventory.EquippedBow);
            }
            else if(weaponSaveData is GrimoireSaveData)
            {
                m_selectedWeaponInfosPanel.InflateGrimoire(weaponSaveData as GrimoireSaveData);
                m_currentWeaponInfosPanel.InflateGrimoire(m_currentSaveData.SavedPlayerWeaponInventory.EquippedGrimoire);
            }
            else
            {
                Debug.LogError("Incorrect weapon !");
            }
        }

        public void QuitPanel()
        {
            EventSystem.current.SetSelectedGameObject(null);
            m_gamemode.Actions.UI.Back.performed -= Back_performed;
            m_gamemode.Actions.Disable();
            Hide();
            m_gamemode.Player.MakeUnbusy();
        }
    }
}