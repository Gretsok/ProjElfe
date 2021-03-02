using System.Collections;
using UnityEngine;

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

            for(int i = 0; i < m_currentSaveData.EarnedWeapon.Count; ++i)
            {
                var newStockedWeaponSlot = Instantiate(m_stockedWeaponSlotPrefab, m_stockedWeaponsContainer);
                newStockedWeaponSlot.Inflate(m_currentSaveData.EarnedWeapon[i]);
            }

            yield return null;

            m_isLoaded = true;
        }

        IEnumerator UnloadInventoryPanelRoutine()
        {
            m_meleeWeaponSlot.Clear();
            m_grimoireSlot.Clear();
            m_bowSlot.Clear();

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

        public void QuitPanel()
        {
            m_gamemode.Actions.UI.Back.performed -= Back_performed;
            m_gamemode.Actions.Disable();
            Hide();
            m_gamemode.Player.MakeUnbusy();
        }
    }
}