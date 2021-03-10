using MOtter.Localization;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace ProjElf.HubForest
{
    public class DunjeonSelectionWidget : MonoBehaviour
    {
        [SerializeField]
        private TextLocalizer m_dunjeonNameLocalizer = null;
        [SerializeField]
        private TextLocalizer m_dunjeonTypeLocalizer = null;
        [SerializeField]
        private TextLocalizer m_dunjeonDifficultyLocalizer = null;
        [SerializeField]
        private Image m_dunjeonIcon = null;

        private DunjeonSelectionData m_dunjeonSelectionData = null;
        private bool m_startedLoading = false;

        public void Inflate(DunjeonSelectionData a_selectionData)
        {
            m_dunjeonNameLocalizer.SetKey(a_selectionData.DunjeonNameKey);
            m_dunjeonTypeLocalizer.SetKey(ProjElfUtils.GetDunjeonTypeKey(a_selectionData.DunjeonType));
            m_dunjeonDifficultyLocalizer.SetKey(ProjElfUtils.GetDifficultyKey(a_selectionData.DunjeonDifficulty));
            m_dunjeonIcon.sprite = a_selectionData.DunjeonIcon;
            m_dunjeonSelectionData = a_selectionData;
        }

        public void OnClick()
        {
            if(!m_startedLoading)
            {
                m_dunjeonSelectionData.DunjeonSceneData.LoadLevel();
                m_startedLoading = true;
            }
        }
    }
}