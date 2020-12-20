using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class HomeState : MainMenuNavigationState
    {
        protected override void GoRight()
        {
            base.GoRight();
            m_mainStateMachine.SwitchToOptionsState();
        }
    }
}