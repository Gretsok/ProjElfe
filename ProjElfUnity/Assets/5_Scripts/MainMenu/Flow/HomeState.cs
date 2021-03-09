using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class HomeState : MainMenuNavigationState
    {
        public override void EnterState()
        {
            base.EnterState();
            m_mainStateMachine.CameraManager.SetHomeCamera();
        }
    }
}