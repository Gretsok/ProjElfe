using UnityEngine;
using TMPro;
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{
    public class CharacterCreationPanel : Panel
    {
        [SerializeField]
        private TMP_InputField m_nameInputField = null;
        public TMP_InputField NameInputField => m_nameInputField;

        [SerializeField]
        private NameGenerationWidget m_nameGenerationWidget = null;
        public TextMeshProUGUI NameLabel => m_nameGenerationWidget.NameLabel;

        [SerializeField]
        private GameObject m_textWidget = null;
    }
}