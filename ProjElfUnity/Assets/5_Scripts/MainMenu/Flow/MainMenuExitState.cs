using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.UI;
using UnityEngine.UI;

namespace ProjElf.MainMenu
{
    public class MainMenuExitState : MainMenuNavigationState
    {
        private enum EPosition
        {
            QuitButton,
            YesButton,
            NoButton
        }
        [SerializeField]
        private MainMenuExitPanel m_panel = null;
        private EPosition m_position = EPosition.QuitButton;
        private GameObject m_quitButton = null;

        private Vector2 m_movement = default;
        public override void EnterState()
        {
            base.EnterState();
            m_position = EPosition.QuitButton;
            m_mainStateMachine.CameraManager.SetQuitCamera();
            m_quitButton = EventSystem.current.currentSelectedGameObject;
            (EventSystem.current.currentInputModule as InputSystemUIInputModule).move.action.performed += Move_performed;
            (EventSystem.current.currentInputModule as InputSystemUIInputModule).submit.action.performed += Submit_performed;
        }

        private void Submit_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            switch(m_position)
            {
                case EPosition.QuitButton:
                    m_panel.SelectNo();
                    EventSystem.current.SetSelectedGameObject(null);
                    m_position = EPosition.NoButton;
                    break;
                case EPosition.NoButton:
                    m_panel.UnselectAll();
                    EventSystem.current.SetSelectedGameObject(m_quitButton);
                    m_position = EPosition.QuitButton;
                    break;
                case EPosition.YesButton:
                    Application.Quit();
                    break;
            }
        }

        private void Move_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_movement = obj.ReadValue<Vector2>();
            if(m_movement.y > 0.3f && m_position == EPosition.QuitButton)
            {
                m_panel.SelectNo();
                EventSystem.current.SetSelectedGameObject(null);
                m_position = EPosition.NoButton;
            }
            if(m_movement.y < -0.3f && m_position != EPosition.QuitButton)
            {
                m_panel.UnselectAll();
                EventSystem.current.SetSelectedGameObject(m_quitButton);
                m_position = EPosition.QuitButton;
            }
            if(m_movement.x < -0.3f && m_position == EPosition.NoButton)
            {
                m_panel.SelectYes();
                m_position = EPosition.YesButton;
            }
            if(m_movement.x > 0.3f && m_position == EPosition.YesButton)
            {
                m_panel.SelectNo();
                m_position = EPosition.NoButton;
            }
        }

        public override void ExitState()
        {
            (EventSystem.current.currentInputModule as InputSystemUIInputModule).move.action.performed -= Move_performed;
            (EventSystem.current.currentInputModule as InputSystemUIInputModule).submit.action.performed -= Submit_performed;
            base.ExitState();
        }
    }
}