using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsTabButton : MonoBehaviour, ISelectHandler, IDeselectHandler
{
    [SerializeField]
    private Image m_image = null;
    [SerializeField]
    private Color32 m_selectedColor = Color.white;
    [SerializeField]
    private Color32 m_unselectedColor = Color.white;
    [SerializeField]
    private OptionsMenuPanel m_panel = null;

    [SerializeField]
    private List<Selectable> m_optionsWidget = null;
    public List<Selectable> OptionsWidget => m_optionsWidget;

    private void Awake()
    {
        if (m_image == null)
        {
            m_image = GetComponent<Image>();
        }

        OnUnselected();
    }

    public void OnSelected()
    {
        m_image.color = m_selectedColor;
        m_panel.Show();
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
        if(!OptionsWidget.Contains(eventData.selectedObject.GetComponent<Selectable>()))
        {
            m_panel.Hide();
        }
    }
}
