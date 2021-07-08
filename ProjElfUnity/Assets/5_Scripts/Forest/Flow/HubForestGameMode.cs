﻿using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ProjElf.AnimalManagement;

namespace ProjElf.HubForest
{
    public class HubForestGameMode : ProjElfGameMode
    {
        private SaveData m_saveData = null;
        private AnimalData m_RandomAnimal = null;

        [SerializeField]
        private ForestGameplayState m_gameplayState = null;
        [SerializeField]
        private ForestDunjeonSelectionState m_dunjeonSelectionState = null;
        [SerializeField]
        private ForestInventoryState m_inventoryState = null;
        [SerializeField]
        private PlayerStatsState m_playerStatsState = null;

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
            ForestHubAudioReferences.Instance.StartHubMusic();
            yield return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_saveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();

            if(m_saveData.IsChoosingAnAnimalToSacrify)
            {
                m_RandomAnimal = m_saveData.GetRandomAnimalData();
                AnimalsManager.GetInstance().SacrificeRescuedAnimal(m_RandomAnimal);
                m_saveData.IsChoosingAnAnimalToSacrify = false;
                Debug.Log($"Randomly sacrifice {m_RandomAnimal.NameKey}");
                //On t'as bien niqué
            }

            ForestHubAudioReferences.Instance.StartHubAmbiance();
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
            ForestHubAudioReferences.Instance.StopHubAmbiance();
            ForestHubAudioReferences.Instance.StopHubMusic();
            base.ExitStateMachine();
        }
    }
}