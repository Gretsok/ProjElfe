using UnityEngine;

public class OptionsMenuModule : MonoBehaviour, INavigationPosition
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
}
