using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using ProjElf.SceneData;
using UnityEngine;
using MOtter;

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
        private OptionsState m_optionsState = null;
        [SerializeField]
        private CreditsState m_creditsState = null;

        [SerializeField]
        private float m_timeToWaitBetweenTwoSwitch = 1f;
        private float m_timeLastSwitched = -10f;

        [Header("LevelLoader")]
        [SerializeField]
        private SceneData.SceneData m_hubData = null;

        public override IEnumerator LoadAsync()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
            return base.LoadAsync();
        }

        public void SwitchToHomeState()
        {
            SwitchToState(m_homeState);
        }

        public void SwitchToCharacterSelectionState()
        {
            SwitchToState(m_characterSelectionState);
        }

        public void SwitchToCreateCharacterState()
        {
            SwitchToState(m_createCharacterState);
        }

        public void SwitchToOptionsState()
        {
            SwitchToState(m_optionsState);
        }

        public void SwitchToCreditsState()
        {
            SwitchToState(m_creditsState);
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