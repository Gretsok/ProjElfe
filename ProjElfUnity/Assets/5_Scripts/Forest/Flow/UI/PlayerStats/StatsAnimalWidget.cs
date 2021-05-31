using MOtter.Localization;
using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;

namespace ProjElf.HubForest
{
    public class StatsAnimalWidget : MonoBehaviour
    {
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
    }
}