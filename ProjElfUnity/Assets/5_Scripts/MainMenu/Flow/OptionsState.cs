using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class OptionsState : MainMenuNavigationState
    {
        protected override void GoLeft()
        {
            base.GoLeft();
            m_mainStateMachine.SwitchToHomeState();
        }

        protected override void GoRight()
        {
            base.GoRight();
            m_mainStateMachine.SwitchToCharacterSelectionState();
        }
    }
}