using MOtter;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuNavigationState : NavigationState
    {
        protected MainMenuStateMachine m_mainStateMachine = null;

        [SerializeField]
        protected NavigationState m_nextSectionState = null;
        [SerializeField]
        protected NavigationState m_previousSectionState = null;

        private void Start()
        {
            m_mainStateMachine = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
        }

        public override void EnterState()
        {
            base.EnterState();
            m_mainStateMachine.Actions.UI.Confirm.performed += Confirm_performed;
            m_mainStateMachine.Actions.UI.Back.performed += Back_performed;
            m_mainStateMachine.Actions.UI.MoveDown.performed += MoveDown_performed;
            m_mainStateMachine.Actions.UI.MoveUp.performed += MoveUp_performed;
            m_mainStateMachine.Actions.UI.MoveLeft.performed += MoveLeft_performed;
            m_mainStateMachine.Actions.UI.MoveRight.performed += MoveRight_performed;
            m_mainStateMachine.Actions.UI.NextSection.performed += NextSection_performed;
            m_mainStateMachine.Actions.UI.PreviousSection.performed += PreviousSection_performed;
        }
        #region InputsHandling
        private void PreviousSection_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoToPreviousSection();
        }

        private void NextSection_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoToNextSection();
        }

        private void MoveRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoRight();
        }

        private void MoveLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoLeft();
        }

        private void MoveUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoUp();
        }

        private void MoveDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            GoDown();
        }

        private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Back();
        }

        private void Confirm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            Confirm();
        }

        #endregion

        public override void UpdateState()
        {
            base.UpdateState();
        }

        #region Navigation
        protected virtual void GoLeft()
        {
            Debug.Log("Going Left");
        }

        protected virtual void GoRight()
        {
            Debug.Log("Going Right");
        }
        protected virtual void GoUp()
        {
            Debug.Log("Going Up");
        }

        protected virtual void GoDown()
        {
            Debug.Log("Going Down");
        }

        protected virtual void GoToNextSection()
        {
            m_mainStateMachine.SwitchToState(m_nextSectionState);
        }

        protected virtual void GoToPreviousSection()
        {
            m_mainStateMachine.SwitchToState(m_previousSectionState);
        }

        protected virtual void Confirm()
        {
            Debug.Log("Confirm");
        }

        protected virtual void Back()
        {
            Debug.Log("Back");
        }
        #endregion
        public override void ExitState()
        {
            m_mainStateMachine.Actions.UI.Confirm.performed -= Confirm_performed;
            m_mainStateMachine.Actions.UI.Back.performed -= Back_performed;
            m_mainStateMachine.Actions.UI.MoveDown.performed -= MoveDown_performed;
            m_mainStateMachine.Actions.UI.MoveUp.performed -= MoveUp_performed;
            m_mainStateMachine.Actions.UI.MoveLeft.performed -= MoveLeft_performed;
            m_mainStateMachine.Actions.UI.MoveRight.performed -= MoveRight_performed;
            m_mainStateMachine.Actions.UI.NextSection.performed -= NextSection_performed;
            m_mainStateMachine.Actions.UI.PreviousSection.performed -= PreviousSection_performed;
            base.ExitState();
        }
    }
}