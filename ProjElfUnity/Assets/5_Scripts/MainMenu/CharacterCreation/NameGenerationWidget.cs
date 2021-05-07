using System.IO;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class NameGenerationWidget : MonoBehaviour
    {
        [SerializeField]
        private SyllablesNameGenerationData m_syllablesData = null;
        private int m_numberOfSyllablesAvailable = 0;

        [SerializeField]
        private TextMeshProUGUI m_nameLabel = null;
        public TextMeshProUGUI NameLabel => m_nameLabel;

        [SerializeField]
        private Vector2Int m_numberOfSyllables = new Vector2Int(2, 3);


        private void Start()
        {
            OnButtonClicked();
        }



        public void OnButtonClicked()
        {
            m_nameLabel.text = GenerateRandomName();
        }

        public string GenerateRandomName()
        {
            string name = "";

            int numberOfSyllables = Random.Range(m_numberOfSyllables.x, m_numberOfSyllables.y + 1);

            for(int i = 0; i < numberOfSyllables; ++i)
            {
                int syllableIndex = Random.Range(0, m_syllablesData.Syllables.Count);
                name += m_syllablesData.Syllables[syllableIndex];
                
            }

            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }
#if UNITY_EDITOR

        private const string path = "Assets/Resources/NameGenerationWidget/syllables.txt";

        public void LoadSyllables()
        {
            SyllablesNameGenerationData syllablesData = ScriptableObject.CreateInstance<SyllablesNameGenerationData>();

            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                syllablesData.AddSyllable(reader.ReadLine());
            }

            EditorUtility.SetDirty(syllablesData);
            string dataPath = "Assets/6_Data/NameGeneration/Syllables.asset";
            AssetDatabase.CreateAsset(syllablesData, dataPath);

            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            reader.Close();
        }
        
#endif
        
    }
#if UNITY_EDITOR
    [CustomEditor(typeof(NameGenerationWidget), true)]
    public class NameGenerationWidgetEditor : Editor
    {
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if(GUILayout.Button("Load syllables"))
            {
                (target as NameGenerationWidget).LoadSyllables();
            }
        }
    }
#endif
}