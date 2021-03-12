using MOtter;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MainMenuNavigationState : NavigationState
    {
        protected MainMenuStateMachine m_mainStateMachine = null;


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
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}