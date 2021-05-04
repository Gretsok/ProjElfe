using UnityEditor;
using UnityEngine;
using UnityEngine.AddressableAssets;

namespace ProjElf.AnimalManagement
{
    [CreateAssetMenu(fileName = "AnimalData", menuName = "Animal/AnimalData")]
    public class AnimalData : ScriptableObject
    {
        [SerializeField, HideInInspector]
        private int m_animalDataID = int.MinValue;
        public int AnimalDataID => m_animalDataID;

        [SerializeField]
        private string m_nameKey = null;
        [SerializeField]
        private EPlayerStats m_statsToIncrease = EPlayerStats.AttackSpeed;
        [SerializeField]
        private float m_statsToIncreaseAmount = 0f;
        [SerializeField]
        private Animal m_animalPrefab = null;
        [SerializeField]
        private Sprite m_animalIcon = null;

        public string NameKey => m_nameKey;
        public float StatToIncreaseAmount => m_statsToIncreaseAmount;
        public EPlayerStats StatsToIncrease => m_statsToIncrease;
        public Animal InstantiateAnimal(Vector3 position, Quaternion rotation, Transform parent = null)
        {
            Animal newAnimal = Instantiate(m_animalPrefab, position, rotation);
            newAnimal.transform.SetParent(parent);
            newAnimal.AnimalData = this;
            return newAnimal;
        }
        public Sprite AnimalIcon => m_animalIcon;


#if UNITY_EDITOR
        internal void GenerateRandomID()
        {
            m_animalDataID = Random.Range(int.MinValue, int.MaxValue);
            EditorUtility.SetDirty(this);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();
        }
#endif
    }

#if UNITY_EDITOR
    [CustomEditor(typeof(AnimalData), true)]
    internal class WeaponIDInspector : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            AnimalData targetAnimalData = (AnimalData)target;
            GUILayout.Label("AnimalData ID : " + targetAnimalData.AnimalDataID);
            if (GUILayout.Button("Generate Random ID"))
            {
                targetAnimalData.GenerateRandomID();
            }
        }
    }
#endif
}