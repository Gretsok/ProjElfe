using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
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
        private const float m_inputDelay = 0.2f;
        private float m_timeOfLastInput = float.MinValue;

        private int m_lastSlotIndex = 0;
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
        private CurrentWeaponSlot m_selectedCurrentWeaponSlot = null;

        [SerializeField]
        private WeaponRenderTextureStudio m_renderTextureStudioPrefab = null;

        [SerializeField]
        private StockedWeaponSlot m_stockedWeaponSlotPrefab = null;
        [SerializeField]
        private Transform m_stockedWeaponsContainer = null;
        private List<StockedWeaponSlot> m_stockedWeaponsSlots = new List<StockedWeaponSlot>();

        [SerializeField]
        private TextMeshProUGUI m_moneyDisplayText = null;

        public override void Show()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
            m_gamemode.Player.MakeBusy(m_inventoryChest.transform);
            base.Show();

   
            StartCoroutine(LoadInventoryPanelRoutine());

            
        }

        #region Player Interactions
        private void Reroll_CurrentItem(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (Time.time - m_timeOfLastInput < m_inputDelay || EventSystem.current.currentSelectedGameObject == null)
            {
                return;
            }
            else
            {
                m_timeOfLastInput = Time.time;
            }

            StockedWeaponSlot stockedWeaponSlot = EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>();

            Debug.Log("Trying to reroll : " + stockedWeaponSlot);
            if (stockedWeaponSlot != null)
            {
                m_currentSaveData.FrancissousMoney -= stockedWeaponSlot.WeaponSaveData.WeaponData.RerollPrice;
                m_currentSaveData.RerollWeapon(stockedWeaponSlot.WeaponSaveData);
            }

            StartCoroutine(UnloadInventoryPanelRoutine(true));
        }

        private void Sell_CurrentItem(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (Time.time - m_timeOfLastInput < m_inputDelay || EventSystem.current.currentSelectedGameObject == null)
            {
                return;
            }
            else
            {
                m_timeOfLastInput = Time.time;
            }

            StockedWeaponSlot stockedWeaponSlot = EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>();
            Debug.Log("Trying to sell : " + stockedWeaponSlot);

            if(stockedWeaponSlot != null)
            {
                m_currentSaveData.FrancissousMoney += stockedWeaponSlot.WeaponSaveData.WeaponData.SellPrice;
                m_currentSaveData.RemoveWeaponFromHoldedWeapons(stockedWeaponSlot.WeaponSaveData);
            }

            StartCoroutine(UnloadInventoryPanelRoutine(true));
        }

        private void Confirm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if(Time.time - m_timeOfLastInput < m_inputDelay || EventSystem.current.currentSelectedGameObject == null)
            {
                return;
            }
            else
            {
                m_timeOfLastInput = Time.time;
            }

            StockedWeaponSlot selectedSlot = EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>();

            if(selectedSlot != null)
            {
                m_gamemode.Player.CombatController.CombatInventory.ChangeWeapon(selectedSlot.WeaponSaveData);
                MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().RemoveWeaponFromHoldedWeapons(selectedSlot.WeaponSaveData);
                Debug.Log("Weapon changed !");
            }

            StartCoroutine(UnloadInventoryPanelRoutine(true));
        }
        private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (m_isLoaded)
            {
                StartCoroutine(UnloadInventoryPanelRoutine());
            }
        }
        #endregion

        #region Loading&Unloading
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

            m_moneyDisplayText.text = $"{m_currentSaveData.FrancissousMoney} francissous";

            yield return null;



            m_isLoaded = true;

            try
            {
                if(m_lastSlotIndex >= m_stockedWeaponsSlots.Count)
                {
                    m_lastSlotIndex = m_stockedWeaponsSlots.Count - 1;
                }

                EventSystem.current.SetSelectedGameObject(m_stockedWeaponsSlots[m_lastSlotIndex].gameObject);

            }
            catch(Exception)
            {
                if (m_stockedWeaponsSlots.Count > 0)
                {
                    EventSystem.current.SetSelectedGameObject(m_stockedWeaponsSlots[0].gameObject);
                }
                else
                {
                    EventSystem.current.SetSelectedGameObject(null);
                }
            }

            

            SetUpInputs();


        }

        IEnumerator UnloadInventoryPanelRoutine(bool reload = false)
        {
            if(EventSystem.current.currentSelectedGameObject != null)
            {
                m_lastSlotIndex = m_stockedWeaponsSlots.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>());
            }
            
            CleanUpInputs();
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
            m_gamemode.SaveData();
            m_gamemode.SavePlayerWeapons();
            EventSystem.current.SetSelectedGameObject(null);
            if (reload)
            {
                
                StartCoroutine(LoadInventoryPanelRoutine());
            }
            else
            {
                m_lastSlotIndex = 0;
                QuitPanel();
            }

        }

        #endregion



        public void SetSelectedWeaponSaveData(AWeaponSaveData weaponSaveData)
        {
            Debug.Log("weapon selected");
            m_selectedCurrentWeaponSlot?.Unselect();
            if (weaponSaveData is MeleeWeaponSaveData)
            {
                m_selectedWeaponInfosPanel.InflateMeleeWeapon(weaponSaveData as MeleeWeaponSaveData);
                m_currentWeaponInfosPanel.InflateMeleeWeapon(m_currentSaveData.SavedPlayerWeaponInventory.EquippedMeleeWeapon);
                m_selectedCurrentWeaponSlot = m_meleeWeaponSlot;
            }
            else if(weaponSaveData is BowSaveData)
            {
                m_selectedWeaponInfosPanel.InflateBow(weaponSaveData as BowSaveData);
                m_currentWeaponInfosPanel.InflateBow(m_currentSaveData.SavedPlayerWeaponInventory.EquippedBow);
                m_selectedCurrentWeaponSlot = m_bowSlot;
            }
            else if(weaponSaveData is GrimoireSaveData)
            {
                m_selectedWeaponInfosPanel.InflateGrimoire(weaponSaveData as GrimoireSaveData);
                m_currentWeaponInfosPanel.InflateGrimoire(m_currentSaveData.SavedPlayerWeaponInventory.EquippedGrimoire);
                m_selectedCurrentWeaponSlot = m_grimoireSlot;
            }
            else
            {
                Debug.LogError("Incorrect weapon !");
            }
            m_selectedCurrentWeaponSlot?.Select();
        }

        public void QuitPanel()
        {


            Hide();
            m_gamemode.Player.MakeUnbusy();
        }

        #region Inputs
        private void SetUpInputs()
        {
            m_gamemode.Actions.Enable();
            m_gamemode.Actions.UI.Back.started += Back_performed;
            m_gamemode.Actions.Generic.PrimaryAttack.started += Sell_CurrentItem;
            m_gamemode.Actions.Generic.SecondaryAttack.started += Reroll_CurrentItem;
            m_gamemode.Actions.UI.Confirm.started += Confirm_performed;
        }


        private void CleanUpInputs()
        {
            m_gamemode.Actions.UI.Back.started -= Back_performed;
            m_gamemode.Actions.Generic.PrimaryAttack.started -= Sell_CurrentItem;
            m_gamemode.Actions.Generic.SecondaryAttack.started -= Reroll_CurrentItem;
            m_gamemode.Actions.UI.Confirm.started -= Confirm_performed;
            m_gamemode.Actions.Disable();
        }
        #endregion
    }
}