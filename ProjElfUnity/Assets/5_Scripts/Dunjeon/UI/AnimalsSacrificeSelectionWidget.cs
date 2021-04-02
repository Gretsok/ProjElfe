using ProjElf.AnimalManagement;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.DunjeonGameplay
{
    public class AnimalsSacrificeSelectionWidget : MonoBehaviour
    {
        [SerializeField]
        private AnimalToSacrificeWidget m_animalToSacrificeWidgetPrefab = null;

        private List<AnimalToSacrificeWidget> m_animalWidgetInstantiated = new List<AnimalToSacrificeWidget>();

        [SerializeField]
        private Transform m_container = null;
        [SerializeField]
        private FlexibleGrid m_flexibleGrid = null;

        public void Inflate(List<RescuedAnimalData> a_rescuedAnimalData)
        {
            for(int i = 0; i < a_rescuedAnimalData.Count; ++i)
            {
                for(int j = 0; j < a_rescuedAnimalData[i].Amount; ++j)
                {
                    AnimalToSacrificeWidget l_newWidget = Instantiate(m_animalToSacrificeWidgetPrefab, m_container);
                    l_newWidget.Inflate(a_rescuedAnimalData[i].AnimalData);
                    m_animalWidgetInstantiated.Add(l_newWidget);
                }
            }
            m_flexibleGrid.UpdateGrid();
            if(m_animalWidgetInstantiated.Count >= 1)
            {
                EventSystem.current.SetSelectedGameObject(m_animalWidgetInstantiated[0].gameObject);
            }
        }
    }
}