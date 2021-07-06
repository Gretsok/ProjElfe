using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.AnimalManagement;

namespace ProjElf.HubForest
{
    public class HubForestGameMode : ProjElfGameMode
    {
        private SaveData m_saveData = null;
        [SerializeField]
        private ForestGameplayState m_gameplayState = null;
        [SerializeField]
        private ForestDunjeonSelectionState m_dunjeonSelectionState = null;
        [SerializeField]
        private ForestInventoryState m_inventoryState = null;
        [SerializeField]
        private PlayerStatsState m_playerStatsState = null;

        private AudioSource m_ambianceAudioSource = null;

        private List<AnimalHubController> m_animals = new List<AnimalHubController>();
        public List<AnimalHubController> Animals => m_animals;
        [SerializeField]
        private AnimalHubController m_animalHubControllerPrefab = null;
        [SerializeField]
        private Transform m_animalSpawnPoint = null;


        public override IEnumerator LoadAsync()
        {
            yield return null;
            InstantiatePlayer();

            if(AnimalsManager.GetInstance().SavedAnimals != null)
            {
                foreach (RescuedAnimalData rescuedAnimalData in AnimalsManager.GetInstance().SavedAnimals)
                {
                    for(int i = 0; i < rescuedAnimalData.Amount; ++i)
                    {
                        AnimalHubController newAnimal = Instantiate(m_animalHubControllerPrefab, m_animalSpawnPoint.position, Quaternion.identity, m_animalSpawnPoint);
                        newAnimal.Init(rescuedAnimalData.AnimalData);
                        m_animals.Add(newAnimal);
                    }
                }
            }

            yield return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_ambianceAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(ForestHubAudioReferences.Ambiance, true);
            m_saveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();

            if(m_saveData.IsChoosingAnAnimalToSacrify)
            {
                //RandomSacrifyAnimal();
            }
        }

        public void ActivateGameplayState()
        {
            SwitchToState(m_gameplayState);
        }

        public void ActivateDunjeonSelectionState()
        {
            SwitchToState(m_dunjeonSelectionState);
        }

        public void ActivateInventoryState()
        {
            SwitchToState(m_inventoryState);
        }

        public void ActivatePlayerDisplay()
        {
            SwitchToState(m_playerStatsState);
        }

        internal override void ExitStateMachine()
        {
            MOtter.MOtterApplication.GetInstance().SOUND.CleanSource(m_ambianceAudioSource);
            base.ExitStateMachine();
        }
    }
}