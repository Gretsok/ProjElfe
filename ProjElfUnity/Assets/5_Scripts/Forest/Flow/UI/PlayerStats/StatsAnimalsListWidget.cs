using ProjElf.AnimalManagement;
using ProjElf.ProceduraleGeneration;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjElf.HubForest
{
    public class StatsAnimalsListWidget : MonoBehaviour
    {
        [SerializeField]
        private List<StatsAnimalWidget> m_animalWidgets = null;

        [SerializeField]
        private List<StatsAnimalWidget> m_AMGAnimalWidgets = null;

        [SerializeField]
        private GameObject m_classicGrid = null;
        [SerializeField]
        private GameObject m_AMGGrid = null;

        public void StartInflate(EDunjeonDifficulty a_difficultySelected)
        {
            Addressables.LoadAssetsAsync<AnimalData>(
                ProjElfUtils.GetDifficultyLabel(a_difficultySelected),
                null).Completed += obj =>
                {
                    if(a_difficultySelected != EDunjeonDifficulty.AbsoluteMasterGuardian)
                    {
                        m_classicGrid.SetActive(true);
                        m_AMGGrid.SetActive(false);
                        foreach (AnimalData animalData in obj.Result)
                        {
                            m_animalWidgets.Find(x => x.Stats == animalData.StatsToIncrease).InflateAnimalData(animalData);
                        }
                    }
                    else
                    {
                        m_classicGrid.SetActive(false);
                        m_AMGGrid.SetActive(true);
                        List<StatsAnimalWidget> l_usedWidgets = new List<StatsAnimalWidget>();
                        foreach(AnimalData animalData in obj.Result)
                        {
                            StatsAnimalWidget widget = m_AMGAnimalWidgets.Find(x => x.Stats == animalData.StatsToIncrease && !l_usedWidgets.Contains(x));
                            widget.InflateAnimalData(animalData);
                            l_usedWidgets.Add(widget);
                        }
                    }
                    
                };
        }
    }
}