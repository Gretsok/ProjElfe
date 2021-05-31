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

        public void StartInflate(EDunjeonDifficulty a_difficultySelected)
        {
            Addressables.LoadAssetsAsync<AnimalData>(
                ProjElfUtils.GetDifficultyLabel(a_difficultySelected),
                null).Completed += obj =>
                {
                    foreach (AnimalData animalData in obj.Result)
                    {
                        m_animalWidgets.Find(x => x.Stats == animalData.StatsToIncrease).InflateAnimalData(animalData);
                    }
                };
        }
    }
}