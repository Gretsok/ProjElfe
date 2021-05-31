using ProjElf.ProceduraleGeneration;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace ProjElf.HubForest
{
    public class DunjeonSelectionPanel : Panel
    {
        [SerializeField]
        private DunjeonSelectionWidget m_dunjeonSelectionWidgetPrefab = null;

        private List<DunjeonSelectionWidget> m_instantiatedDunjeonSelectionWidget = new List<DunjeonSelectionWidget>();
        
        [SerializeField]
        private List<DunjeonData> m_dunjeonSelectionData = new List<DunjeonData>();


        public override void Show()
        {
            base.Show();
            SetUpPanel();
        }

        private void SetUpPanel()
        {
            for(int i = m_instantiatedDunjeonSelectionWidget.Count - 1; i >= 0; --i)
            {
                Destroy(m_instantiatedDunjeonSelectionWidget[i].gameObject);
                m_instantiatedDunjeonSelectionWidget.RemoveAt(i);
            }

            for(int i = 0; i < m_dunjeonSelectionData.Count; ++i)
            {
                if(m_dunjeonSelectionData[i].DunjeonDifficulty <= MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>().DifficultyToBeat)
                {
                    var dunjeonSelectionWidget = Instantiate(m_dunjeonSelectionWidgetPrefab, transform);
                    dunjeonSelectionWidget.Inflate(m_dunjeonSelectionData[i]);
                    m_instantiatedDunjeonSelectionWidget.Add(dunjeonSelectionWidget);
                }
            }

            if(m_instantiatedDunjeonSelectionWidget.Count > 0)
            {
                EventSystem.current.SetSelectedGameObject(m_instantiatedDunjeonSelectionWidget[0].gameObject);
            }
        }
    }
}