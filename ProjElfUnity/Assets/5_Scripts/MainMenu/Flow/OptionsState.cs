using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class OptionsState : MainMenuNavigationState
    {
        [SerializeField]
        private OptionsStateMachine m_subStateMachine = null;

        public override void EnterState()
        {
            base.EnterState();
            m_subStateMachine.EnterStateMachine();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            m_subStateMachine.DoUpdate();
        }

        public override void FixedUpdateState()
        {
            base.FixedUpdateState();
            m_subStateMachine.DoFixedUpdate();
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            m_subStateMachine.DoLateUpdate();
        }

        public override void ExitState()
        {
            m_subStateMachine.ExitStateMachine();
            base.ExitState();
        }

        protected override void GoDown()
        {
            base.GoDown();
            m_subStateMachine.GoDown();
        }

        protected override void GoLeft()
        {
            base.GoLeft();
            m_subStateMachine.GoLeft();
        }

        protected override void GoRight()
        {
            base.GoRight();
            m_subStateMachine.GoRight();
        }

        protected override void GoUp()
        {
            base.GoUp();
            m_subStateMachine.GoUp();
        }

        protected override void Confirm()
        {
            base.Confirm();
        }

        protected override void Back()
        {
            base.Back();
            m_subStateMachine.Back();
        }

    }
}