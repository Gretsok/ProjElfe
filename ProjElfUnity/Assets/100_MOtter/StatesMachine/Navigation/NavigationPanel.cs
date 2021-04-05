using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;

public class NavigationPanel : Panel
{
    [SerializeField]
    private GameObject m_defaultGameObjectSelected = null;

    public override void Show()
    {
        base.Show();
        EventSystem.current.SetSelectedGameObject(m_defaultGameObjectSelected);
    }

    public override void Hide()
    {
        EventSystem.current.SetSelectedGameObject(null);
        base.Hide();
    }
}
