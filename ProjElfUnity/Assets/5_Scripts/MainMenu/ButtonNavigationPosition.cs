using MOtter.StatesMachine;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjElf.MainMenu
{ 
    public class ButtonNavigationPosition : MonoBehaviour, INavigationPosition, ISelectHandler, IDeselectHandler
    {
        private MainMenuStateMachine m_mainStatesMachine = null;
        [SerializeField]
        private Image m_image = null;
        [SerializeField]
        private Color32 m_selectedColor = Color.white;
        [SerializeField]
        private Color32 m_unselectedColor = Color.white;


        [SerializeField]
        private State m_state = null;

        private void Awake()
        {
            if(m_image == null)
            {
                m_image = GetComponent<Image>();
            }
            OnUnselected();
        }

        private void Start()
        {
            m_mainStatesMachine = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
        }

        public void OnSelected()
        {
            m_image.color = m_selectedColor;
            if(m_state != null)
                m_mainStatesMachine?.SwitchToState(m_state);
        }

        public void OnUnselected()
        {
            m_image.color = m_unselectedColor;
        }

        public void OnSelect(BaseEventData eventData)
        {
            OnSelected();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            OnUnselected();
        }
    }
}