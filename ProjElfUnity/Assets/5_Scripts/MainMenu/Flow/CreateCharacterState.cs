using MOtter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CreateCharacterState : MainMenuNavigationState
    {
        protected override void Back()
        {
            base.Back();
            m_mainStateMachine.SwitchToCharacterSelectionState();
        }

        protected override void Confirm()
        {
            base.Confirm();
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