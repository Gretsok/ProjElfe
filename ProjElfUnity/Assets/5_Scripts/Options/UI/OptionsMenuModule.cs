using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OptionsMenuModule : Selectable, INavigationPosition
{
    [SerializeField]
    private Vector3 m_selectedScale = Vector3.zero;
    [SerializeField]
    private Vector3 m_unselectedScale = Vector3.zero;
    public void OnSelected()
    {
        transform.localScale = m_selectedScale;
    }

    public void OnUnselected()
    {
        transform.localScale = m_unselectedScale;
    }

    public override void OnSelect(BaseEventData eventData)
    {
        base.OnSelect(eventData);
        OnSelected();
    }

    public override void OnDeselect(BaseEventData eventData)
    {
        base.OnDeselect(eventData);
        OnUnselected();
    }
}
