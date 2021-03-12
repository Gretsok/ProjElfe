using System.Collections;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class NameGenerationWidget : MonoBehaviour
    {
        private const string path = "Assets/Resources/NameGenerationWidget/syllables.txt";
        private int m_numberOfSyllablesAvailable = 0;

        [SerializeField]
        private TextMeshProUGUI m_nameLabel = null;
        public TextMeshProUGUI NameLabel => m_nameLabel;

        [SerializeField]
        private Vector2Int m_numberOfSyllables = new Vector2Int(2, 3);


        private void Start()
        {
            SetUp();
            OnButtonClicked();
        }

        private void SetUp()
        {
            StreamReader reader = new StreamReader(path);
            m_numberOfSyllablesAvailable = 0;
            while (!reader.EndOfStream)
            {
                reader.ReadLine();
                m_numberOfSyllablesAvailable++;
            }
            reader.Close();
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
                int syllableIndex = Random.Range(0, m_numberOfSyllablesAvailable);
                int currentLineIndex = 0;
                StreamReader reader = new StreamReader(path);
                while (!reader.EndOfStream)
                {
                    if(currentLineIndex == syllableIndex)
                    {
                        name += reader.ReadLine();
                        break;
                    }
                    else
                    {
                        reader.ReadLine();
                    }
                    
                    currentLineIndex++;
                }
                reader.Close();
            }

            name = char.ToUpper(name[0]) + name.Substring(1);

            return name;
        }
    }
}