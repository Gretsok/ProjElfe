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


        [SerializeField]
        private SavedProfilesManager m_profileManager = null;
        public SavedProfilesManager ProfileManager => m_profileManager;

        [Header("LevelLoader")]
        [SerializeField]
        private SceneData.SceneData m_hubData = null;

        public override IEnumerator LoadAsync()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
            return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
        }


        internal override void ExitStateMachine()
        {
            base.ExitStateMachine();
            m_actions.Disable();
            m_actions.Dispose();
        }

        public void LoadHub(SaveData saveDataToUse)
        {
            MOtterApplication.GetInstance().GAMEMANAGER.UseSaveData(saveDataToUse);
            m_hubData.LoadLevel();
        }
    }
}