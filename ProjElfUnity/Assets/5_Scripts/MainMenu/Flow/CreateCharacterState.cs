using MOtter;
using ProjElf.CombatController;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class CreateCharacterState : MainMenuNavigationState
    {
        [SerializeField]
        private GameObject m_firstSelectedGO = null;
        public override void EnterState()
        {
            base.EnterState();
            EventSystem.current.SetSelectedGameObject(m_firstSelectedGO);
            m_mainStateMachine.CameraManager.SetCharacterCamera();
        }

        public void Confirm()
        {
            SaveData newSaveData = new SaveData();
            newSaveData.SaveName = GetPanel<CharacterCreationPanel>().NameLabel.text;
            newSaveData.SavedPlayerStats.TimePlayed = 0;
            newSaveData.SavedPlayerStats.DunjeonFinished = 0;
            newSaveData.SavedPlayerStats.MonsterKilled = 0;
            newSaveData.SavedPlayerStats.NumberOfDeath = 0;

            SaveData.PlayerWeaponInventory startingInventory = default;
            startingInventory.EquippedMeleeWeapon = m_mainStateMachine.ProfileManager.StartingMeleeWeaponData.GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>();
            startingInventory.EquippedGrimoire = m_mainStateMachine.ProfileManager.StartingGrimoireData.GetWeaponSaveData<GrimoireData.GrimoireSaveData>();
            startingInventory.EquippedBow = m_mainStateMachine.ProfileManager.StartingBowData.GetWeaponSaveData<BowData.BowSaveData>();

            newSaveData.SavedPlayerWeaponInventory = startingInventory;

            MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveData(newSaveData);
            MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
            m_mainStateMachine.LoadHub(newSaveData);
        }
    }
}