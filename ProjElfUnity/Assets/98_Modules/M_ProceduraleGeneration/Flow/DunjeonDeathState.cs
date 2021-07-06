using MOtter.StatesMachine;
using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.DunjeonGameplay
{
    public class DunjeonDeathState : UIState
    {
        private SaveData m_saveData = null;

        [SerializeField]
        private DunjeonGameMode m_gamemode = null;

        private DunjeonDeathPanel m_deathPanel = null;

        private bool m_hasSacrifiedAnimal = false;

        [SerializeField]
        private float m_timeToWaitToGoToHub = 3f;

        public override void EnterState()
        {
            base.EnterState();
            InflateDeathPanel();
            m_saveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();
            m_saveData.IsChoosingAnAnimalToSacrify = true;
        }

        private void InflateDeathPanel()
        {
            m_deathPanel = GetPanel<DunjeonDeathPanel>();
            if(AnimalsManager.GetInstance().SavedAnimals.Count == 0)
            {
                StartCoroutine(GoingBackToHubRoutine());
            }
            m_deathPanel.Inflate(AnimalsManager.GetInstance().SavedAnimals);
        }

        public void SacrificeAnimal(AnimalData animalData)
        {
            if(!m_hasSacrifiedAnimal)
            {
                AnimalsManager.GetInstance().SacrificeRescuedAnimal(animalData);
                EventSystem.current.SetSelectedGameObject(null);
                StartCoroutine(GoingBackToHubRoutine());
                m_hasSacrifiedAnimal = true;
                m_saveData.IsChoosingAnAnimalToSacrify = false;
            }
        }

        IEnumerator GoingBackToHubRoutine()
        {
            yield return new WaitForSeconds(m_timeToWaitToGoToHub);
            m_gamemode.LoadBackToHub();
        }

        public override void ExitState()
        {
            base.ExitState();
        }
    }
}