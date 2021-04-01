using ProjElf.AnimalManagement;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.DunjeonGameplay
{
    public class DunjeonDeathPanel : Panel
    {
        [SerializeField]
        private AnimalsSacrificeSelectionWidget m_animalsSacrificeSelectionWidget = null;
        
        public void Inflate(List<RescuedAnimalData> a_rescuedAnimalsData)
        {
            m_animalsSacrificeSelectionWidget.Inflate(a_rescuedAnimalsData);
        }
    }
}