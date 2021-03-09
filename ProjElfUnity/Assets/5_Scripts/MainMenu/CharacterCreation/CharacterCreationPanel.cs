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
        private GameObject m_textWidget = null;

        private void Start()
        {
            EventSystem.current.SetSelectedGameObject(m_textWidget);
        }



    }
}