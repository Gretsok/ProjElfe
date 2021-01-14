using UnityEngine;
using TMPro;

namespace ProjElf.MainMenu
{
    public class CharacterCreationPanel : Panel
    {
        [SerializeField]
        private TMP_InputField m_nameInputField = null;
        public TMP_InputField NameInputField => m_nameInputField;
    }
}