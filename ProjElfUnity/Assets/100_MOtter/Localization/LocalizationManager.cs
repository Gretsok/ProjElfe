using System.Collections.Generic;
using System.IO;
using UnityEngine;



namespace MOtter.Localization
{

    public class LocalizationManager : MonoBehaviour
    {
        private const string path = "Assets/Resources/Localization.tsv";
        #region Fields
        private bool isInit = false;

        #region Language Management
        private int m_currentLanguageIndex = 0;
        private Dictionary<string, int> m_indexesOfLanguagesShortNames = new Dictionary<string, int>();
        private int m_numberOfLanguages = 0;
        public int NumberOfLanguages => m_numberOfLanguages;
        #endregion

        #region Localizers
        private Dictionary<string, string> m_currentLanguageDictionary = new Dictionary<string, string>();
        private TextLocalizer[] m_registeredTextLocalizers = new TextLocalizer[0];
        #endregion
        #endregion

        #region Methods
        #region Language Management
        private void Start()
        {
            if (!isInit)
            {
                Init();
            }
        }

        private void Init()
        {
            m_numberOfLanguages = GetNumberMaxOfLanguages();
            SwitchLanguage(m_currentLanguageIndex);
            isInit = true;
        }

        public void SwitchLanguage(int languageIndex)
        {
            m_currentLanguageIndex = languageIndex % NumberOfLanguages;
            if (m_currentLanguageIndex < 0)
            {
                m_currentLanguageIndex = NumberOfLanguages + m_currentLanguageIndex;
            }
            Debug.Log("language index : " + m_currentLanguageIndex);
            m_currentLanguageDictionary = LoadCurrentLanguage();
            UpdateLocalizers();
        }

        public void SwitchToNextLanguage()
        {
            SwitchLanguage(m_currentLanguageIndex + 1);
        }

        public void SwitchToPreviousLanguage()
        {
            SwitchLanguage(m_currentLanguageIndex - 1);
        }

        private int GetNumberMaxOfLanguages()
        {
            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            int charIndex = 0;
            int numberOfTabs = 0;
            while (charIndex < line.Length)
            {
                if (line[charIndex] == '\t')
                {
                    numberOfTabs++;
                }
                charIndex++;
            }
            return numberOfTabs;
        }

        /// <summary>
        /// Returns the dictonary of the language defined by languageIndex
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        private Dictionary<string, string> LoadLanguage(int languageIndex)
        {
            Dictionary<string, string> languageDictionary = new Dictionary<string, string>();
            StreamReader reader = new StreamReader(path);
            while (!reader.EndOfStream)
            {
                string line = reader.ReadLine();
                string key = "";
                string translation = "";


                int charIndex = 0;
                // Getting the key
                while (charIndex < line.Length && line[charIndex] != '\t')
                {
                    key = key + line[charIndex];
                    charIndex++;
                }

                int browsedLanguageIndex = 0;
                // Browsing to the language we want to load
                while (browsedLanguageIndex < languageIndex)
                {
                    charIndex++;
                    if (charIndex >= line.Length)
                    {
                        Debug.LogError("Language Index doesn't exist");
                    }
                    else if (line[charIndex] == '\t')
                    {
                        browsedLanguageIndex++;
                    }
                }
                charIndex++;

                // Getting the translation of the key in the language selected
                while (charIndex < line.Length && line[charIndex] != '\t')
                {
                    translation = translation + line[charIndex];
                    charIndex++;
                }

                languageDictionary.Add(key, translation);
                Debug.Log("Add " + translation + " for " + key);
            }
            reader.Close();
            return languageDictionary;
        }

        /// <summary>
        /// Returns the dictonary of the current Language
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        private Dictionary<string, string> LoadCurrentLanguage()
        {
            return LoadLanguage(m_currentLanguageIndex);
        }
        #endregion

        #region Localizers
        /// <summary>
        /// Add a TextLocalizer to the Localization system to update it
        /// </summary>
        /// <param name="textLocalizer"></param>
        public void RegisterTextLocalizer(TextLocalizer textLocalizer)
        {
            if (!isInit)
            {
                Init();
            }
            Debug.Log("Register new text localizer on " + textLocalizer.name);
            TextLocalizer[] tempRegisteredTextLocalizers = new TextLocalizer[m_registeredTextLocalizers.Length];
            tempRegisteredTextLocalizers = m_registeredTextLocalizers;
            m_registeredTextLocalizers = new TextLocalizer[m_registeredTextLocalizers.Length + 1];
            for (int i = 0; i < m_registeredTextLocalizers.Length - 1; i++)
            {
                m_registeredTextLocalizers[i] = tempRegisteredTextLocalizers[i];
            }
            m_registeredTextLocalizers[m_registeredTextLocalizers.Length - 1] = textLocalizer;
            UpdateLocalizers();
        }

        /// <summary>
        /// Remove a TextLocalizer to the Localization system
        /// </summary>
        /// <param name="textLocalizer"></param>
        public void UnregisterTextLocalizer(TextLocalizer textLocalizer)
        {
            TextLocalizer[] tempRegisteredTextLocalizers = new TextLocalizer[m_registeredTextLocalizers.Length];
            tempRegisteredTextLocalizers = m_registeredTextLocalizers;
            int textLocalizerToRemoveIndex = -1;
            Debug.Log("Unregister new text localizer on " + textLocalizer.name + " | the total of text Localizers is " + m_registeredTextLocalizers.Length);
            int index = 0;
            while (index < m_registeredTextLocalizers.Length)
            {
                Debug.Log(index);
                if (textLocalizer == m_registeredTextLocalizers[index])
                {
                    textLocalizerToRemoveIndex = index;
                    break;
                }
                index++;
            }

            if (textLocalizerToRemoveIndex == -1)
            {
                Debug.LogError("TextLocalizer to delete not found !");
                return;
            }
            m_registeredTextLocalizers = new TextLocalizer[m_registeredTextLocalizers.Length - 1];
            for (int i = 0; i < textLocalizerToRemoveIndex; i++)
            {
                m_registeredTextLocalizers[i] = tempRegisteredTextLocalizers[i];
            }
            for (int i = textLocalizerToRemoveIndex; i < m_registeredTextLocalizers.Length; i++)
            {
                m_registeredTextLocalizers[i] = tempRegisteredTextLocalizers[i + 1];
            }
        }

        public string Localize(string key)
        {
            string translation = "";
            if (m_currentLanguageDictionary.TryGetValue(key, out translation))
            {
                return translation;
            }
            else
            {
                Debug.LogWarning("No translation found for key : " + key);
                return key;
            }
        }

        public string Localize(string key, int languageIndex)
        {
            Debug.LogWarning("NOT IMPLEMENTED YET");
            if (languageIndex == m_currentLanguageIndex)
            {
                return Localize(key);
            }
            return key;
        }

        private void UpdateLocalizers()
        {
            for (int i = 0; i < m_registeredTextLocalizers.Length; i++)
            {
                var textLocalizer = m_registeredTextLocalizers[i];
                textLocalizer.TextTarget.text = Localize(textLocalizer.Key);
                if (textLocalizer.Formatter != null)
                    textLocalizer.Formatter.Invoke(textLocalizer.TextTarget.text, textLocalizer);
            }
        }
        #endregion
        #endregion
    }
}
