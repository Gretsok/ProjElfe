using MOtter;
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
    private TextMeshProUGUI m_timePlayedText = null;
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
        
        m_selectedSaveNameText.text = saveData.SaveName;
        m_unselectedSaveNameText.text = saveData.SaveName;
        int secondsPlayed = saveData.SavedPlayerStats.TimePlayed;
        int minutesPlayed = secondsPlayed / 60;
        int hoursPlayed = minutesPlayed / 60;
        minutesPlayed -= hoursPlayed * 60;

        if(minutesPlayed > 0)
        {
            string minuteText = (minutesPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTES") : MOtterApplication.GetInstance().LOCALIZATION.Localize("MINUTE");
            if (hoursPlayed > 0)
            {
                string hourText = (hoursPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("HOURS") : MOtterApplication.GetInstance().LOCALIZATION.Localize("HOUR");
                string andText = MOtterApplication.GetInstance().LOCALIZATION.Localize("GENERIC_AND");
                m_timePlayedText.text = $"{hoursPlayed} {hourText} {andText} {minutesPlayed} {minuteText}";
            }
            else
            {
                m_timePlayedText.text = $"{minutesPlayed} {minuteText}";
            }
        }
        else
        {
            if (hoursPlayed > 0)
            {
                string hourText = (hoursPlayed > 1) ? MOtterApplication.GetInstance().LOCALIZATION.Localize("HOURS") : MOtterApplication.GetInstance().LOCALIZATION.Localize("HOUR");
                m_timePlayedText.text = $"{hoursPlayed} {hourText}";
            }
            else
            {
                m_timePlayedText.text = $"{MOtterApplication.GetInstance().LOCALIZATION.Localize("HAVE_NOT_PLAYED_YET")}";
            }
        }

        int animalsSaved = 0;
        for(int i = 0; i < saveData.SavedAnimalDatas.Count; ++i)
        {
            animalsSaved += saveData.SavedAnimalDatas[i].Amount;
        }

        m_animalsSavedText.text = animalsSaved.ToString();
        
    }
}
