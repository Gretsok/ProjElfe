﻿using MOtter.StatesMachine;
using ProjElf.CombatController;
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.HubForest
{
    public class ForestInventoryState : UIState
    {
        private const float m_inputDelay = 0.2f;
        private float m_timeOfLastInput = float.MinValue;



        private int m_lastSlotIndex = 0;
        private bool m_isLoaded = false;

        private HubForestGameMode m_gamemode = null;
        private SaveData m_currentSaveData = null;

        private InventoryPanel m_panel = null;

        public override void EnterState()
        {
            base.EnterState();
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
            m_panel = GetPanel<InventoryPanel>();
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

            if (stockedWeaponSlot != null)
            {
                m_currentSaveData.FrancissousMoney += stockedWeaponSlot.WeaponSaveData.WeaponData.SellPrice;
                m_currentSaveData.RemoveWeaponFromHoldedWeapons(stockedWeaponSlot.WeaponSaveData);
            }

            StartCoroutine(UnloadInventoryPanelRoutine(true));
        }

        private void Confirm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            if (Time.time - m_timeOfLastInput < m_inputDelay || EventSystem.current.currentSelectedGameObject == null)
            {
                return;
            }
            else
            {
                m_timeOfLastInput = Time.time;
            }

            StockedWeaponSlot selectedSlot = EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>();

            if (selectedSlot != null)
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

            m_panel.InflateCurrentWeaponsData(m_currentSaveData.SavedPlayerWeaponInventory.EquippedMeleeWeapon,
                m_currentSaveData.SavedPlayerWeaponInventory.EquippedBow,
                m_currentSaveData.SavedPlayerWeaponInventory.EquippedGrimoire);
  
            if (m_gamemode.Player.CombatController.CombatInventory.MeleeWeapon != null)
            {
                m_panel.InflateCurrentMeleeWeapon(m_gamemode.Player.CombatController.CombatInventory.MeleeWeapon.WeaponSaveData.WeaponData as MeleeWeaponData);
                yield return null;
            }
            if (m_gamemode.Player.CombatController.CombatInventory.Grimoire != null)
            {
                m_panel.InflateCurrentGrimoire(m_gamemode.Player.CombatController.CombatInventory.Grimoire.WeaponSaveData.WeaponData as GrimoireData);
                yield return null;
            }
            if (m_gamemode.Player.CombatController.CombatInventory.Bow != null)
            {
                m_panel.InflateCurrentBow(m_gamemode.Player.CombatController.CombatInventory.Bow.WeaponSaveData.WeaponData as BowData);
                yield return null;
            }


            m_panel.InflateEarnedMeleeWeapons(m_currentSaveData.EarnedMeleeWeapons);

            m_panel.InflateEarnedBow(m_currentSaveData.EarnedBows);

            m_panel.InflateEarnedGrimoire(m_currentSaveData.EarnedGrimoires);

            m_panel.InflateMoney(m_currentSaveData.FrancissousMoney);

            yield return null;



            m_isLoaded = true;

            try
            {
                if (m_lastSlotIndex >= m_panel.StockedWeaponSlots.Count)
                {
                    m_lastSlotIndex = m_panel.StockedWeaponSlots.Count - 1;
                }

                EventSystem.current.SetSelectedGameObject(m_panel.StockedWeaponSlots[m_lastSlotIndex].gameObject);

            }
            catch (Exception)
            {
                if (m_panel.StockedWeaponSlots.Count > 0)
                {
                    EventSystem.current.SetSelectedGameObject(m_panel.StockedWeaponSlots[0].gameObject);
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
            if (EventSystem.current.currentSelectedGameObject != null)
            {
                m_lastSlotIndex = m_panel.StockedWeaponSlots.IndexOf(EventSystem.current.currentSelectedGameObject.GetComponent<StockedWeaponSlot>());
            }

            CleanUpInputs();

            m_panel.ClearSlots();

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
                m_gamemode.ActivateGameplayState();
            }

        }

        #endregion

        public override void ExitState()
        {
            base.ExitState();
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