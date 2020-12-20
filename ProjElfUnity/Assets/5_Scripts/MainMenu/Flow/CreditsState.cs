using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CreditsState : MainMenuNavigationState
    {
        protected override void GoLeft()
        {
            base.GoLeft();
            m_mainStateMachine.SwitchToCharacterSelectionState();
        }

    }
}