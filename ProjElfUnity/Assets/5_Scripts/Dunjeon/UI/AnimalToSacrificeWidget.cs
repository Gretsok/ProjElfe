using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjElf.DunjeonGameplay
{
    public class AnimalToSacrificeWidget : MonoBehaviour, ISelectHandler
    {
        [SerializeField]
        private Image m_animalIcon = null;
        [SerializeField]
        private Button m_button = null;
        private AnimalData m_animalData = null;
        public AnimalData AnimalData => m_animalData;

        private DunjeonDeathPanel m_panel = null;

        private void Start()
        {
            m_button.onClick.AddListener(OnButtonClicked);
        }

        private void OnButtonClicked()
        {
            MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>().GetCurrentState<DunjeonDeathState>().SacrificeAnimal(m_animalData);
        }

        public void Inflate(AnimalData a_animalData, DunjeonDeathPanel a_deathPanel)
        {
            m_animalData = a_animalData;
            m_animalIcon.sprite = m_animalData.AnimalIcon;
            m_panel = a_deathPanel;
        }

        private void OnDestroy()
        {
            m_button.onClick.RemoveAllListeners();
        }

        public void OnSelect(BaseEventData eventData)
        {
            m_panel.SelectAnimal(m_animalData);
        }
    }
}