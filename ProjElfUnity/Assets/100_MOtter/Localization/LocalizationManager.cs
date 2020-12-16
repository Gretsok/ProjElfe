using System.Collections.Generic;
using System.IO;
using UnityEditor;
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
        [SerializeField]
        private AllLanguagesData m_allLanguagesData = null;
        private LanguageData m_currentLanguageData = null;
        #endregion

        #region Localizers
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
#if UNITY_EDITOR
            GenerateLocalizationData();
#endif
            SwitchLanguage(m_currentLanguageIndex);
            isInit = true;
        }

        public void SwitchLanguage(int languageIndex)
        {
            m_currentLanguageIndex = GetValidIndex(languageIndex);
            Debug.Log("language index : " + m_currentLanguageIndex);
            m_currentLanguageData = LoadCurrentLanguage();
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

        private LanguageData LoadLanguage(int index)
        {
            return m_allLanguagesData.GetLanguageData(index);
        }
        

        /// <summary>
        /// Returns the dictonary of the current Language
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        private LanguageData LoadCurrentLanguage()
        {
            return LoadLanguage(m_currentLanguageIndex);
        }
        #endregion

        #region ReadingLanguageManagement
        /// <summary>
        /// Returns the dictonary of the language defined by languageIndex
        /// </summary>
        /// <param name="languageIndex"></param>
        /// <returns></returns>
        private LanguageDictionary ReadLanguage(int languageIndex)
        {
            LanguageDictionary languageDictionary = new LanguageDictionary();
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
            if (m_currentLanguageData.LanguageDictionary.TryGetValue(key, out translation))
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
            string translation = "";
            if (m_allLanguagesData.GetLanguageData(GetValidIndex(languageIndex)).LanguageDictionary.TryGetValue(key, out translation))
            {
                return translation;
            }
            else
            {
                Debug.LogWarning("No translation found for key : " + key);
                return key;
            }
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

        #region Utils
#if UNITY_EDITOR
        public void GenerateLocalizationData()
        {
            Debug.Log("Generate Languages Data");

            StreamReader reader = new StreamReader(path);
            string line = reader.ReadLine();
            int charIndex = 0;
            int numberOfLanguage = 0;
            while (charIndex < line.Length)
            {
                if (line[charIndex] == '\t')
                {
                    numberOfLanguage++;
                }
                charIndex++;
            }

            for(int i = 0; i < numberOfLanguage; i++)
            {
                LanguageData newLanguageData = ScriptableObject.CreateInstance<LanguageData>();
                newLanguageData.SetLanguageDictionary(ReadLanguage(i));

                string languageDataPath = "Assets/6_Data/Languages/LanguageData" + i + ".asset";
                AssetDatabase.CreateAsset(newLanguageData, languageDataPath);
                m_allLanguagesData.AddOrModifiyLanguageData(newLanguageData, i);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();
            }
        }
#endif

        public int GetValidIndex(int index)
        {
            int indexToReturn = 0;
            indexToReturn = index % m_allLanguagesData.NumberOfLanguages;
            if (indexToReturn < 0)
            {
                indexToReturn = m_allLanguagesData.NumberOfLanguages + indexToReturn;
            }

            return indexToReturn;
        }
        #endregion
        #endregion
    }

    internal class LanguageDictionary : Dictionary<string, string>
    {

    }
}
