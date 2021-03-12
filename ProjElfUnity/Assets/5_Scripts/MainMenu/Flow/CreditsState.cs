using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CreditsState : MainMenuNavigationState
    {
        public override void EnterState()
        {
            base.EnterState();
            m_mainStateMachine.CameraManager.SetCreditsCamera();
        }
    }
}