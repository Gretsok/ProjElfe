using MOtter;
using ProjElf.CombatController;
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
        private CreateCharacterButtonNavigationPosition m_createNewCharacterButtonPrefab = null;
        [SerializeField]
        private CharacterModel m_characterModel = null;
        [SerializeField]
        private Button m_playButton = null;
        private List<Button> m_instantiatedNavigationPositions = new List<Button>();

        private MainMenuStateMachine m_mainStateMachine = null;

        public int NumberOfNavigationPositions => m_instantiatedNavigationPositions.Count;


        private const int MAX_PROFILES = 8;

        [Header("Starting Weapons")]
        [SerializeField]
        private BowData m_startingBowData = null;
        [SerializeField]
        private GrimoireData m_startingGrimoireData = null;
        [SerializeField]
        private MeleeWeaponData m_startingMeleeWeaponData = null;

        public BowData StartingBowData => m_startingBowData;
        public GrimoireData StartingGrimoireData => m_startingGrimoireData;
        public MeleeWeaponData StartingMeleeWeaponData => m_startingMeleeWeaponData;


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
                navTemp.mode = Navigation.Mode.Explicit;
                navTemp.selectOnUp = lastButton;
                navTemp.selectOnDown = firstButton;
                m_playButton.navigation = navTemp;
            }
        }

        public void InflateSaveData(SavedProfileModule profile)
        {
            m_characterModel.InflateSaveData(profile.SaveData);
        }

        public void InflateNewData()
        {
            m_characterModel.InflateWeapons(m_startingBowData.GetWeaponSaveData<BowData.BowSaveData>(), m_startingMeleeWeaponData.GetWeaponSaveData<MeleeWeaponData.MeleeWeaponSaveData>(), m_startingGrimoireData.GetWeaponSaveData<GrimoireData.GrimoireSaveData>());
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

            CreateCharacterButtonNavigationPosition createNewCharacterButton = Instantiate(m_createNewCharacterButtonPrefab, transform);

            var createNewCharacButton = createNewCharacterButton.GetComponent<Button>();
            Button lastButton = null;
            Navigation navTemp = default;

            if(m_instantiatedNavigationPositions.Count > 0)
            {
                var prevButton = m_instantiatedNavigationPositions[m_instantiatedNavigationPositions.Count - 1];

                navTemp = prevButton.navigation;
                navTemp.selectOnDown = createNewCharacButton;
                prevButton.navigation = navTemp;

                navTemp = createNewCharacButton.navigation;
                navTemp.selectOnUp = prevButton;
                createNewCharacButton.navigation = navTemp;
            }

            

            m_instantiatedNavigationPositions.Add(createNewCharacButton);

        }
    }
}