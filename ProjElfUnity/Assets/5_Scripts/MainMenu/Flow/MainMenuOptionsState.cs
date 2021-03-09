using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuOptionsState : MainMenuNavigationState
    {
        public override void EnterState()
        {
            base.EnterState();
            m_mainStateMachine.CameraManager.SetOptionsCamera();
        }
    }
}