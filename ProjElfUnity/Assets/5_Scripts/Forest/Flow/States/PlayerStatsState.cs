using MOtter.StatesMachine;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.HubForest
{
    public class PlayerStatsState : UIState
    {
        [SerializeField]
        private GameObject m_defaultSelectedGO = null;
        private HubForestGameMode m_gamemode = null;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }

        public override void EnterState()
        {
            base.EnterState();
            EventSystem.current.SetSelectedGameObject(m_defaultSelectedGO);
            m_gamemode.Actions.FindActionMap("UI").FindAction("Back").performed += PlayerStatsState_performed;
        }

        private void PlayerStatsState_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_gamemode.ActivateGameplayState();
        }

        public override void ExitState()
        {
            m_gamemode.Actions.FindActionMap("UI").FindAction("Back").performed -= PlayerStatsState_performed;
            base.ExitState();
        }
    }
}