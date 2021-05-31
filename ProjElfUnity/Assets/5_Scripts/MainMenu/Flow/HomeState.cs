using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class HomeState : MainMenuNavigationState
    {
        [SerializeField]
        private GameObject m_goToSelectOnNextState = null;
        public override void EnterState()
        {
            base.EnterState();
            m_mainStateMachine.CameraManager.SetHomeCamera();
            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("Confirm").started += ButtonPressed;
        }

        private void ButtonPressed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_mainStateMachine.SwitchToNextState();
            EventSystem.current.SetSelectedGameObject(m_goToSelectOnNextState);
        }

        public override void ExitState()
        {
            m_mainStateMachine.Actions.FindActionMap("UI").FindAction("Confirm").started -= ButtonPressed;
            base.ExitState();
        }
    }
}