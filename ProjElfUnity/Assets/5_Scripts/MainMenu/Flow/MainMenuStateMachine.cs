using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{ 
    public class MainMenuStateMachine : MainStatesMachine
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

        private PlayerInputsActions m_actions = null;
        public PlayerInputsActions Actions => m_actions;

        [SerializeField]
        private float m_timeToWaitBetweenTwoSwitch = 1f;
        private float m_timeLastSwitched = -10f;

        public override IEnumerator LoadAsync()
        {
            m_actions = new PlayerInputsActions();
            m_actions.Enable();
            return base.LoadAsync();
        }

        
        protected override void EnterStateMachine()
        {
            base.EnterStateMachine();
            
        }

        protected override void ExitStateMachine()
        {
            base.ExitStateMachine();
            m_actions.Disable();
            m_actions.Dispose();
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

        public override void SwitchToState(State state)
        {
            if(Time.time - m_timeLastSwitched > m_timeToWaitBetweenTwoSwitch)
            {
                base.SwitchToState(state);
                m_timeLastSwitched = Time.time;
            }
        }
    }
}