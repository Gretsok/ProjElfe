using System.Collections.Generic;
using UnityEngine;


namespace ProjElf.MainMenu
{
    public class SyllablesNameGenerationData : ScriptableObject
    {
        [SerializeField]
        private List<string> m_syllables = new List<string>();

        public List<string> Syllables => m_syllables;

        public void AddSyllable(string syllable)
        {
            m_syllables.Add(syllable);
        }
    }
}