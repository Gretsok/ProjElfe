using MOtter;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class CreateCharacterState : MainMenuNavigationState
    {


        public void Confirm()
        {
            SaveData newSaveData = new SaveData();
            newSaveData.SaveName = GetPanel<CharacterCreationPanel>().NameInputField.text;
            newSaveData.SavedPlayerStats.TimePlayed = 0;
            newSaveData.SavedPlayerStats.DunjeonFinished = 0;
            newSaveData.SavedPlayerStats.MonsterKilled = 0;
            newSaveData.SavedPlayerStats.NumberOfDeath = 0;

            MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveData(newSaveData);
            MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
            m_mainStateMachine.LoadHub(newSaveData);
        }
    }
}