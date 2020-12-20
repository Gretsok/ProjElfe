﻿using MOtter;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuNavigationState : NavigationState
    {
        protected MainMenuStateMachine m_mainStateMachine = null;

        private Vector2 m_movement = Vector2.zero;

        private void Start()
        {
            m_mainStateMachine = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
        }

        public override void EnterState()
        {
            base.EnterState();
           
        }

        public override void UpdateState()
        {
            base.UpdateState();

            m_movement = m_mainStateMachine.Actions.Generic.Move.ReadValue<Vector2>();
            if (m_movement.x > 0.3 && Mathf.Abs(m_movement.y) < 0.3)
            {
                GoRight();
            }
            else if(m_movement.x < -0.3 && Mathf.Abs(m_movement.y) < 0.3)
            {
                GoLeft();
            }
            else if (m_movement.y > 0.3 && Mathf.Abs(m_movement.x) < 0.3)
            {
                GoUp();
            }
            else if (m_movement.y < -0.3 && Mathf.Abs(m_movement.x) < 0.3)
            {
                GoDown();
            }
            Debug.Log(m_movement);
        }

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

        protected virtual void Confirm()
        {
            Debug.Log("Confirm");
        }

        public override void ExitState()
        {
            base.ExitState();

        }
    }
}