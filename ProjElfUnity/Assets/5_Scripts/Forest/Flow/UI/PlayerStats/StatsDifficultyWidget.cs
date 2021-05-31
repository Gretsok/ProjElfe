using MOtter.Localization;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.HubForest
{
    public class StatsDifficultyWidget : MonoBehaviour, ISelectHandler
    {
        [SerializeField]
        private StatsAnimalsListWidget m_animalListWidget = null;
        [SerializeField]
        private ProceduraleGeneration.EDunjeonDifficulty m_difficulty = default;

        [SerializeField]
        private TextLocalizer m_textLocalizer = null;

        public void OnSelect(BaseEventData eventData)
        {
            m_animalListWidget.StartInflate(m_difficulty);
        }

        private void Start()
        {
            m_textLocalizer.SetKey(ProjElfUtils.GetDifficultyKey(m_difficulty));
        }
    }
}