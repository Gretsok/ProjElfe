using MOtter.Localization;
using ProjElf.AnimalManagement;
using UnityEngine;

public class AnimalToSacrificeSelectedInfoWidget : MonoBehaviour
{
    [SerializeField]
    private TextLocalizer m_animalNameLocalizer = null;
    [SerializeField]
    private TextLocalizer m_animalStatLocalizer = null;

    public void Inflate(AnimalData animalData)
    {
        m_animalNameLocalizer.SetKey(animalData.NameKey);
        m_animalStatLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(animalData.StatsToIncrease));
        m_animalStatLocalizer.SetFormatter((text, localizer) =>
        {
            localizer.TextTarget.text = $"{text} : +{animalData.StatToIncreaseAmount}";
        });
    }
}
