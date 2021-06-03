﻿using ProjElf.AnimalManagement;
using ProjElf.Interaction;
using ProjElf.ProceduraleGeneration;
using UnityEngine;

namespace ProjElf.DunjeonGameplay
{
    public class AnimalPrison : MonoBehaviour, IInteractable
    {
        [SerializeField]
        private Transform m_animalSpawnPoint = null;

        private AnimalData m_animalDataToRescue = null;
        private bool m_hasRescuedAnimal = false;

        public AnimalData AnimalDataToRescue => m_animalDataToRescue;

        public void Init(EDunjeonDifficulty dunjeonDifficulty)
        {
            AnimalsManager.GetInstance().GetAsyncRandomAnimalData(OnAnimalDataGot, dunjeonDifficulty);
        }

        private void OnAnimalDataGot(AnimalData animalDataReceived)
        {
            m_animalDataToRescue = animalDataReceived;
            m_animalDataToRescue.InstantiateAnimal(m_animalSpawnPoint.position, m_animalSpawnPoint.rotation, m_animalSpawnPoint);
        }

        public void DoInteraction(Interactor interactor)
        {
            if(!m_hasRescuedAnimal)
            {
                AnimalsManager.GetInstance().RescueAnimal(m_animalDataToRescue);
                Destroy(m_animalSpawnPoint.GetChild(0).gameObject);
                m_hasRescuedAnimal = true;
                MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>().WinDunjeon();
            }
        }

        public void StartBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).ShowPossibleInteraction("INTERACT_SAVE_ANIMAL", null);
        }

        public void StopBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).HidePossibleInteraction();
        }
    }
}