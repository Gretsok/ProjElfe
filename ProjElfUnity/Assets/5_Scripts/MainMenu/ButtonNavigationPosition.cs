using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationPosition : MonoBehaviour, INavigationPosition
{
    private Image m_image = null;
    [SerializeField]
    private Color32 m_selectedColor;
    [SerializeField]
    private Color32 m_unselectedColor;
    private void Awake()
    {
        m_image = GetComponent<Image>();
        OnUnselected();
    }

    public void OnSelected()
    {
        m_image.color = m_selectedColor;
    }

    public void OnUnselected()
    {
        m_image.color = m_unselectedColor;
    }
}
