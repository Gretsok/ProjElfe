using MOtter.Localization;
using ProjElf.AnimalManagement;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.DunjeonGameplay
{
    public class RescuedAnimalPanel : Panel
    {
        [SerializeField]
        private TextLocalizer m_animalSavedLocalizer = null;

        [SerializeField]
        private Image m_animalIconeImage = null;

        [SerializeField]
        private RescuedAnimalPreview m_rescuedAnimalPreview = null;

        public void Inflate(AnimalData animalData)
        {
            m_animalSavedLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = string.Format(text, MOtter.MOtterApplication.GetInstance().LOCALIZATION.Localize(animalData.NameKey + ProjElfUtils.GetInSentenceSuffixForKeys()));
            });
            m_animalIconeImage.sprite = animalData.AnimalIcon;
            m_rescuedAnimalPreview.Inflate(animalData);
        }
    }
}