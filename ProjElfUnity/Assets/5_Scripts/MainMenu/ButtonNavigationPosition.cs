using MOtter.StatesMachine;
using Tween;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace ProjElf.MainMenu
{ 
    public class ButtonNavigationPosition : MonoBehaviour, ISelectHandler, IDeselectHandler
    {
        public enum EStateActivationType
        {
            OnSelect,
            OnClick,
            None
        }

        protected MainMenuStateMachine m_mainStatesMachine = null;
        [SerializeField]
        private Image m_image = null;
        [SerializeField]
        private Color32 m_selectedColor = Color.white;
        [SerializeField]
        private Color32 m_unselectedColor = Color.white;
        [SerializeField]
        private ScaleTween m_selectedTween = null;

        [SerializeField]
        private EStateActivationType m_stateActivationType = EStateActivationType.OnSelect;
        [SerializeField]
        protected State m_state = null;

        private void Awake()
        {
            if(m_image == null)
            {
                m_image = GetComponent<Image>();
            }

            OnUnselected();
        }

        protected virtual void Start()
        {
            if(m_mainStatesMachine == null)
            {
                m_mainStatesMachine = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainMenuStateMachine>();
            }

            if (m_stateActivationType == EStateActivationType.OnClick)
            {
                GetComponent<Button>().onClick.AddListener(OnClick);
            }
        }
        
        public virtual void OnSelected()
        {
            m_image.color = m_selectedColor;
            m_selectedTween?.StartTween();
            if(m_state != null && m_stateActivationType == EStateActivationType.OnSelect)
                m_mainStatesMachine?.SwitchToState(m_state);
        }

        public void OnUnselected()
        {
            m_image.color = m_unselectedColor;
            m_selectedTween?.StopAllAttachedTweens();
        }

        public void OnSelect(BaseEventData eventData)
        {
            OnSelected();
        }

        public void OnDeselect(BaseEventData eventData)
        {
            OnUnselected();
        }

        protected virtual void OnClick()
        {
            if(m_state != null)
            {
                m_mainStatesMachine?.SwitchToState(m_state);
            }
        }
    }
}