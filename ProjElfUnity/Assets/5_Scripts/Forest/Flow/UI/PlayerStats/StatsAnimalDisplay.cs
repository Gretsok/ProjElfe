using MOtter.Localization;
using ProjElf.AnimalManagement;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class StatsAnimalDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextLocalizer m_statsTextLocalizer = null;

        private void Start()
        {
            CleanUp();
        }

        public void SetUp(AnimalData animalData)
        {
            m_statsTextLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(animalData.StatsToIncrease));
            m_statsTextLocalizer.SetFormatter((text, localizer) => {
                localizer.TextTarget.text = $"{text} : +{animalData.StatToIncreaseAmount}";
            });
        }

        public void CleanUp()
        {
            m_statsTextLocalizer.TextTarget.text = string.Empty;
        }
    }
}