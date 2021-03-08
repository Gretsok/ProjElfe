using MOtter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
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
        [SerializeField]
        private Button m_playButton = null;
        private List<Button> m_instantiatedNavigationPositions = new List<Button>();

        private MainMenuStateMachine m_mainStateMachine = null;

        public int NumberOfNavigationPositions => m_instantiatedNavigationPositions.Count;


        private const int MAX_PROFILES = 5;


        private void Start()
        {
            if (m_mainStateMachine == null)
            {
                m_mainStateMachine = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
            }
        }

        public void Inflate(SaveDataElement[] allSaveData)
        {
            if (m_mainStateMachine == null)
            {
                m_mainStateMachine = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
            }
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


            if (m_instantiatedNavigationPositions.Count > 0)
            {
                var firstButton = m_instantiatedNavigationPositions[0];
                //button.navigation.selectOnRight = m_playButton;
                Navigation navTemp = firstButton.navigation;
                navTemp.selectOnUp = m_playButton;
                firstButton.navigation = navTemp;

                var lastButton = m_instantiatedNavigationPositions[m_instantiatedNavigationPositions.Count - 1];
                navTemp = lastButton.navigation;
                navTemp.selectOnDown = m_playButton;
                lastButton.navigation = navTemp;

                navTemp = m_playButton.navigation;
                navTemp.selectOnUp = lastButton;
                navTemp.selectOnDown = firstButton;
                m_playButton.navigation = navTemp;
            }
        }

        public void InflateSaveData(SavedProfileModule profile)
        {
            m_characterModel.InflateSaveData(profile.SaveData);
        }

        private void AddSavedProfileModule(SaveData saveData)
        {

            SavedProfileModule newSaveProfileModule = Instantiate(m_savedProfileModulePrefab, transform);
            newSaveProfileModule.Inflate(saveData);
            newSaveProfileModule.OnUnselected();
            var button = newSaveProfileModule.GetComponent<Button>();
            button.onClick.AddListener(m_mainStateMachine.CharacterSelectionState.Confirm);
            if(m_instantiatedNavigationPositions.Count > 0)
            {
                var prevButton = m_instantiatedNavigationPositions[m_instantiatedNavigationPositions.Count - 1];

                Navigation navTemp = prevButton.navigation;
                navTemp.selectOnDown = button;
                prevButton.navigation = navTemp;

                navTemp = button.navigation;
                navTemp.selectOnUp = prevButton;
                button.navigation = navTemp;
            }
            m_instantiatedNavigationPositions.Add(button);
        }

        private void CreateCreateNewCharacterButton()
        {

            ButtonNavigationPosition createNewCharacterButton = Instantiate(m_createNewCharacterButtonPrefab, transform);

            var createNewCharacButton = createNewCharacterButton.GetComponent<Button>();

            var lastButton = m_instantiatedNavigationPositions[m_instantiatedNavigationPositions.Count - 1];
            Navigation navTemp = lastButton.navigation;
            navTemp.selectOnDown = createNewCharacButton;
            lastButton.navigation = navTemp;

            navTemp = createNewCharacButton.navigation;
            navTemp.selectOnUp = lastButton;
            navTemp.selectOnDown = m_playButton;
            createNewCharacButton.navigation = navTemp;

            m_instantiatedNavigationPositions.Add(createNewCharacButton);

        }
    }
}