using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CharacterSelectionState : MainMenuNavigationState
    {
        protected override void GoLeft()
        {
            base.GoLeft();
            m_mainStateMachine.SwitchToOptionsState();
        }

        protected override void GoRight()
        {
            base.GoRight();
            m_mainStateMachine.SwitchToCreditsState();
        }
    }
}