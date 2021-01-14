using UnityEngine;

public class VCAMNavigationPosition : MonoBehaviour, INavigationPosition
{
    private void Awake()
    {
        OnUnselected();
    }

    public void OnSelected()
    {
        gameObject.SetActive(true);
    }

    public void OnUnselected()
    {
        gameObject.SetActive(false);
    }
}
