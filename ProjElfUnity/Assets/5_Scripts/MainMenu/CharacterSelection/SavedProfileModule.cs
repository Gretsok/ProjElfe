using MOtter;
using MOtter.Localization;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SavedProfileModule : MonoBehaviour, INavigationPosition
{
    [SerializeField, Tooltip("")]
    private LayoutElement m_layoutElement = null;
    [SerializeField]
    private GameObject m_selectedElementDisplay = null;
    [SerializeField]
    private GameObject m_unselectedElementDisplay = null;

    [Header("UI Components")]
    [SerializeField]
    private TextMeshProUGUI m_selectedSaveNameText = null;
    [SerializeField]
    private TextMeshProUGUI m_unselectedSaveNameText = null;
    [SerializeField]
    private TextLocalizer m_timePlayedText = null;
    [SerializeField]
    private TextMeshProUGUI m_animalsSavedText = null;

    private SaveData m_saveData = null;
    public SaveData SaveData => m_saveData;

    public void OnSelected()
    {
        m_layoutElement.preferredHeight = 200;
        //m_layoutElement.preferredHeight = (transform as RectTransform).rect.height; //  TO TRY FOR CONSISTENCY
        m_unselectedElementDisplay.SetActive(false);
        m_selectedElementDisplay.SetActive(true);
        LayoutRebuilder.MarkLayoutForRebuild((transform as RectTransform));
    }

    public void OnUnselected()
    {
        m_layoutElement.preferredHeight = 100;
        m_unselectedElementDisplay.SetActive(true);
        m_selectedElementDisplay.SetActive(false);
        LayoutRebuilder.MarkLayoutForRebuild((transform as RectTransform));
    }

    public void Inflate(SaveData saveData)
    {
        m_saveData = saveData;
        
        // Inflates name
        m_selectedSaveNameText.text = saveData.SaveName;
        m_unselectedSaveNameText.text = saveData.SaveName;

        // Inflates time played, converting seconds to minutes, to hours
        int secondsPlayed = saveData.SavedPlayerStats.TimePlayed;
        int minutesPlayed = secondsPlayed / 60;
        int hoursPlayed = minutesPlayed / 60;
        minutesPlayed -= hoursPlayed * 60;

        if(minutesPlayed > 0)
        {
            if (hoursPlayed > 0)
            {
                
                m_timePlayedText.SetFormatter((text, localizer) =>
                {
                    string minuteText = (minutesPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTES") : MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTE");
                    string hourText = (hoursPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("HOURS") : MOtterApplication.GetInstance().LOCALIZATION.Localize("HOUR");
                    string andText = MOtterApplication.GetInstance().LOCALIZATION.Localize("GENERIC_AND");
                    localizer.TextTarget.text = $"{hoursPlayed} {hourText} {andText} {minutesPlayed} {minuteText}";
                });
            }
            else
            {
                m_timePlayedText.SetFormatter((text, localizer) =>
                {
                    string minuteText = (minutesPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTES") : MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTE");
                    localizer.TextTarget.text = $"{minutesPlayed} {minuteText}";
                });
            }
        }
        else
        {
            if (hoursPlayed > 0)
            {
                
                m_timePlayedText.SetFormatter((text, localizer) => 
                {
                    string hourText = (hoursPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("HOURS") : MOtterApplication.GetInstance().LOCALIZATION.Localize("HOUR");
                    localizer.TextTarget.text = $"{hoursPlayed} {hourText}";
                });
            }
            else
            {
                m_timePlayedText.SetFormatter((text, localizer) => localizer.TextTarget.text = $"{MOtterApplication.GetInstance().LOCALIZATION.Localize("HAVE_NOT_PLAYED_YET")}");
            }
        }


        // Inflates number of animals saved
        int animalsSaved = 0;
        for(int i = 0; i < saveData.SavedAnimalDatas.Count; ++i)
        {
            animalsSaved += saveData.SavedAnimalDatas[i].Amount;
        }

        m_animalsSavedText.text = animalsSaved.ToString();
        
    }
}
