using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonNavigationPosition : MonoBehaviour, INavigationPosition
{
    private Button m_button = null;
    private void Awake()
    {
        m_button = GetComponent<Button>();
        OnUnselected();
    }

    public void OnSelected()
    {
        m_button.Select();
    }

    public void OnUnselected()
    {

    }
}
