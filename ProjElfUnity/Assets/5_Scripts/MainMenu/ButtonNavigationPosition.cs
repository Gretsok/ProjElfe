using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationPosition : MonoBehaviour, INavigationPosition
{
    [SerializeField]
    private Image m_image = null;
    [SerializeField]
    private Color32 m_selectedColor = Color.white;
    [SerializeField]
    private Color32 m_unselectedColor = Color.white;
    private void Awake()
    {
        if(m_image == null)
        {
            m_image = GetComponent<Image>();
        }
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
