using MOtter.StatesMachine;


namespace ProjElf.HubForest
{
    public class ForestDunjeonSelectionState : UIState
    {
        private HubForestGameMode m_gamemode = null;
        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }
        public override void EnterState()
        {
            base.EnterState();
            m_gamemode.Actions.Enable();
            m_gamemode.Actions.FindActionMap("UI").FindAction("Back").performed += Back_performed;
            m_gamemode.Player.CombatController.UIManager.Hide();
        }

        private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_gamemode.ActivateGameplayState();
        }

        public override void ExitState()
        {
            m_gamemode.Player.CombatController.UIManager.Show();
            m_gamemode.Actions.FindActionMap("UI").FindAction("Back").performed -= Back_performed;
            base.ExitState();
        }
    }
}