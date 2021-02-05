using MOtter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static SaveDataManager;

namespace ProjElf.MainMenu
{
    public class SavedProfilesManager : MonoBehaviour
    {
        [SerializeField]
        private SavedProfileModule m_savedProfileModulePrefab = null;
        [SerializeField]
        private ButtonNavigationPosition m_createNewCharacterButtonPrefab = null;
        [SerializeField]
        private CharacterModel m_characterModel = null;

        private List<INavigationPosition> m_instantiatedNavigationPositions = new List<INavigationPosition>();
        public INavigationPosition m_selectedPosition;

        public int NumberOfNavigationPositions => m_instantiatedNavigationPositions.Count;

        private const int MAX_PROFILES = 5;

        public void Inflate(SaveDataElement[] allSaveData)
        {
            for (int i = 0; i < allSaveData.Length; ++i)
            {
                /*SaveData saveData = new SaveData();
                SaveDataManager.LoadFromFile(allSaveData[i].FileName, out string json);
                saveData.LoadFromJson(json);*/

                SaveData saveData = MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.LoadSaveData(allSaveData[i].SaveName);
                AddSavedProfileModule(saveData);
            }

            if (m_instantiatedNavigationPositions.Count < MAX_PROFILES)
            {
                CreateCreateNewCharacterButton();
            }

        }

        public void SelectPosition(int index)
        {
            if (m_selectedPosition != null)
            {
                m_selectedPosition.OnUnselected();
            }
            m_selectedPosition = m_instantiatedNavigationPositions[index];
            if(!IsCurrentSelectionCreateCharacterButton())
            {
                m_characterModel.InflateSaveData(GetSaveDataByPositionIndex(index));
            }
            m_selectedPosition.OnSelected();
        }

        public void UnselectCurrentSelection()
        {
            m_selectedPosition?.OnUnselected();
        }

        public bool IsCurrentSelectionCreateCharacterButton()
        {
            return m_selectedPosition is CreateCharacterButtonNavigationPosition;
        }

        private void AddSavedProfileModule(SaveData saveData)
        {
            SavedProfileModule newSaveProfileModule = Instantiate(m_savedProfileModulePrefab, transform);
            newSaveProfileModule.Inflate(saveData);
            newSaveProfileModule.OnUnselected();
            m_instantiatedNavigationPositions.Add(newSaveProfileModule);
        }

        public SaveData GetSaveDataByPositionIndex(int index)
        {
            if (m_instantiatedNavigationPositions[index] is SavedProfileModule)
            {
                return (m_instantiatedNavigationPositions[index] as SavedProfileModule).SaveData;
            }
            return null;
        }

        private void CreateCreateNewCharacterButton()
        {
            ButtonNavigationPosition createNewCharacterButton = Instantiate(m_createNewCharacterButtonPrefab, transform);
            m_instantiatedNavigationPositions.Add(createNewCharacterButton);
        }
    }
}