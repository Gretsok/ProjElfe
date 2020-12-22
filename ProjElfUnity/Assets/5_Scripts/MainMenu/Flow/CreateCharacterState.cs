using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CreateCharacterState : MainMenuNavigationState
    {
        protected override void Back()
        {
            base.Back();
            m_mainStateMachine.SwitchToCharacterSelectionState();
        }
    }
}