using MOtter.Localization;
using ProjElf.AnimalManagement;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class StatsAnimalDisplay : MonoBehaviour
    {
        [SerializeField]
        private RenderTextureStudio m_renderTextureStudioPrefab = null;
        private RenderTextureStudio m_renderTextureStudio = null;
        [SerializeField]
        private RenderTexture m_animalRenderTexture = null;

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
                localizer.TextTarget.text = $"{text} : +{animalData.StatToIncreaseAmount}  <color=\"green\">x{AnimalsManager.GetInstance().GetNumberOfRescuedAnimals(animalData)}</color>";
            });


            InitStudio();
            m_renderTextureStudio.Inflate(animalData.AnimalPrefab.gameObject, m_animalRenderTexture);
        }


        private void InitStudio()
        {
            if (m_renderTextureStudio == null)
            {
                m_renderTextureStudio = Instantiate(m_renderTextureStudioPrefab, new Vector3(10000, 10000, 8450), Quaternion.identity);
            }
            m_renderTextureStudio.DeleteObjectSpawned();
        }

        public void CleanUp()
        {
            if(m_statsTextLocalizer.TextTarget != null)
                m_statsTextLocalizer.TextTarget.text = string.Empty;
            m_renderTextureStudio?.DeleteObjectSpawned();
        }
    }
}