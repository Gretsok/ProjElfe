using UnityEngine;

namespace ProjElf.AnimalManagement
{
    [CreateAssetMenu(fileName = "AnimalData", menuName = "Animal/AnimalData")]
    public class AnimalData : ScriptableObject
    {
        [SerializeField]
        private EPlayerStats m_statsToIncrease = EPlayerStats.Force;
        [SerializeField]
        private int m_statsToIncreaseAmount = 0;
        [SerializeField]
        private Animal m_animalPrefab = null;

        public int StatToIncreaseAmount => m_statsToIncreaseAmount;
        public EPlayerStats StatsToIncrease => m_statsToIncrease;
        public Animal InstantiateAnimal(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Animal newAnimal = Instantiate(m_animalPrefab, position, rotation);
            newAnimal.transform.SetParent(parent);
            newAnimal.AnimalData = this;
            return newAnimal;
        }
    }
}