using MOtter.Localization;
using ProjElf.AnimalManagement;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjElf.HubForest
{
    public class StatsAnimalWidget : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        [SerializeField]
        private StatsAnimalDisplay m_statsAnimalDisplay = null;
        [SerializeField]
        private TextLocalizer m_textLocalizer = null;
        [SerializeField]
        private Image m_iconImage = null;
        [SerializeField]
        private EPlayerStats m_stats = default;
        public EPlayerStats Stats => m_stats;

        private AnimalData m_currentAnimalData = null;


        public void InflateAnimalData(AnimalData a_animalData)
        {
            m_currentAnimalData = a_animalData;
            m_textLocalizer.SetKey(a_animalData.NameKey);
            m_iconImage.sprite = a_animalData.AnimalIcon;
        }


        public void OnSelect(BaseEventData eventData)
        {
            m_statsAnimalDisplay.SetUp(m_currentAnimalData);
        }

        public void OnDeselect(BaseEventData eventData)
        {
            m_statsAnimalDisplay.CleanUp();
        }
    }
}