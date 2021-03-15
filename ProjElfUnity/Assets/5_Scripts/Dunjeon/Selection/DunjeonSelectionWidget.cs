using MOtter.Localization;
using ProjElf.ProceduraleGeneration;
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

        private DunjeonData m_dunjeonData = null;
        private bool m_startedLoading = false;

        public void Inflate(DunjeonData a_dunjeonData)
        {
            m_dunjeonNameLocalizer.SetKey(a_dunjeonData.DunjeonName);
            m_dunjeonTypeLocalizer.SetKey(ProjElfUtils.GetDunjeonTypeKey(a_dunjeonData.DunjeonType));
            m_dunjeonDifficultyLocalizer.SetKey(ProjElfUtils.GetDifficultyKey(a_dunjeonData.DunjeonDifficulty));
            m_dunjeonIcon.sprite = a_dunjeonData.DunjeonIcon;
            m_dunjeonData = a_dunjeonData;
        }

        public void OnClick()
        {
            if(!m_startedLoading)
            {
                DunjeonDataTransmitter.CreateInstance(m_dunjeonData);
                m_dunjeonData.DunjeonSceneData.LoadLevel();
                m_startedLoading = true;
            }
        }
    }
}