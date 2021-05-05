using MOtter.StatesMachine;
using ProjElf.ProceduraleGeneration;

namespace ProjElf.DunjeonGameplay
{
    public class DunjeonRescuedAnimalState : UIState
    {
        private DunjeonGameMode m_gamemode = null;

        public override void EnterState()
        {
            base.EnterState();
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
            m_gamemode.Actions.Enable();
            m_gamemode.Actions.FindActionMap("UI").FindAction("Confirm").performed += Confirm_performed;
            GetPanel<RescuedAnimalPanel>().Inflate(m_gamemode.AnimalDataToRescue);
        }

        private void Confirm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
        {
            m_gamemode.LoadBackToHub();
        }

        public override void ExitState()
        {
            m_gamemode.Actions.FindActionMap("UI").FindAction("Confirm").performed -= Confirm_performed;
            m_gamemode.Actions.Disable();
            base.ExitState();
        }
    }
}