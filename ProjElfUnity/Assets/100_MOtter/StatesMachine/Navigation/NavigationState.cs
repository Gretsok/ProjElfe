using MOtter.StatesMachine;
using System.Collections.Generic;
using UnityEngine;

public class NavigationState : UIState
{
    [SerializeField]
    private GameObject[] m_navigationPositionsGO = null;

    private List<INavigationPosition> m_navigationPositions = new List<INavigationPosition>();

    private void Awake()
    {
        for(int i = 0; i < m_navigationPositionsGO.Length; ++i)
        {
            if(m_navigationPositionsGO[i].TryGetComponent<INavigationPosition>(out INavigationPosition navPos))
            {
                m_navigationPositions.Add(navPos);
            }
        }
    }

    public override void EnterState()
    {
        base.EnterState();
        for(int i = 0; i < m_navigationPositions.Count; ++i)
        {
            m_navigationPositions[i].OnSelected();
        }
    }


    public override void ExitState()
    {
        base.ExitState();
        for (int i = 0; i < m_navigationPositions.Count; ++i)
        {
            m_navigationPositions[i].OnUnselected();
        }
    }
}
