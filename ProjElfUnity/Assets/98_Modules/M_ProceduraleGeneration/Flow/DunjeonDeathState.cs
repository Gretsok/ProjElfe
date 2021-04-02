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

        private bool m_hasSacrifiedAnimal = false;

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

        public void SacrificeAnimal(AnimalData animalData)
        {
            if(!m_hasSacrifiedAnimal)
            {
                AnimalsManager.GetInstance().SacrificeRescuedAnimal(animalData);
                m_gamemode.LoadBackToHub();
                m_hasSacrifiedAnimal = true;
            }
        }

        public override void ExitState()
        {
            
            base.ExitState();
        }
    }
}