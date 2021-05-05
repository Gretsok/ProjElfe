using MOtter.Localization;
using ProjElf.AnimalManagement;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.DunjeonGameplay
{
    public class DunjeonDeathPanel : Panel
    {
        [SerializeField]
        private AnimalsSacrificeSelectionWidget m_animalsSacrificeSelectionWidget = null;

        [SerializeField]
        private TextLocalizer m_rescuedAnimalsText = null;

        [SerializeField]
        private AnimalToSacrificeSelectedInfoWidget m_selectedAnimalInfoWidget = null;
        
        public void Inflate(List<RescuedAnimalData> a_rescuedAnimalsData)
        {
            m_animalsSacrificeSelectionWidget.Inflate(a_rescuedAnimalsData,this);
            if(a_rescuedAnimalsData.Count == 0)
            {
                m_rescuedAnimalsText.gameObject.SetActive(false);
            }
            else
            {
                m_rescuedAnimalsText.SetFormatter((text, localizer) =>
                {
                    localizer.TextTarget.text = string.Format(text, (a_rescuedAnimalsData.Count));
                });
            }
        }

        public void SelectAnimal(AnimalData animalData)
        {
            m_selectedAnimalInfoWidget.Inflate(animalData);
        }
    }
}