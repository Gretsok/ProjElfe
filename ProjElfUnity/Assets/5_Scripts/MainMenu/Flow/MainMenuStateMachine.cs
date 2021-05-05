using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using ProjElf.SceneData;
using UnityEngine;
using MOtter;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{ 
    public class MainMenuStateMachine : ProjElfMenuStateMachine
    {
        [SerializeField]
        private HomeState m_homeState = null;
        [SerializeField]
        private CharacterSelectionState m_characterSelectionState = null;
        [SerializeField]
        private CreateCharacterState m_createCharacterState = null;
        [SerializeField]
        private CreditsState m_creditsState = null;
        public CharacterSelectionState CharacterSelectionState => m_characterSelectionState;
        public CreateCharacterState CreateCharacterState => m_createCharacterState;

        [SerializeField]
        private GameObject m_firstSelectObject = null;


        [SerializeField]
        private SavedProfilesManager m_profileManager = null;
        public SavedProfilesManager ProfileManager => m_profileManager;
        [SerializeField]
        private MainMenuCameraManager m_cameraManager = null;
        public MainMenuCameraManager CameraManager => m_cameraManager;

        [Header("LevelLoader")]
        [SerializeField]
        private SceneData.SceneData m_hubData = null;

        public override IEnumerator LoadAsync()
        {
            m_actions = MOtterApplication.GetInstance().PLAYERPROFILES.GetActions(0);
            m_actions.Enable();
            return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            EventSystem.current.SetSelectedGameObject(m_firstSelectObject);
        }


        internal override void ExitStateMachine()
        {
            base.ExitStateMachine();
            m_actions.Disable();
        }

        public void LoadHub(SaveData saveDataToUse)
        {
            MOtterApplication.GetInstance().GAMEMANAGER.UseSaveData(saveDataToUse);
            m_hubData.LoadLevel();
        }
    }
}