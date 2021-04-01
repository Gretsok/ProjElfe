using MOtter.StatesMachine;
using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using UnityEngine;

namespace ProjElf.DunjeonGameplay
{
    public class DunjeonDeathState : UIState
    {
        [SerializeField]
        private DunjeonGameMode m_gamemode = null;

        private DunjeonDeathPanel m_deathPanel = null;
        public override void EnterState()
        {
            base.EnterState();
            InflateDeathPanel();
        }

        private void InflateDeathPanel()
        {
            m_deathPanel = GetPanel<DunjeonDeathPanel>();
            m_deathPanel.Inflate(AnimalsManager.GetInstance().SavedAnimals);
        }

        public override void ExitState()
        {
            m_gamemode.LoadBackToHub();
            base.ExitState();
        }
    }
}