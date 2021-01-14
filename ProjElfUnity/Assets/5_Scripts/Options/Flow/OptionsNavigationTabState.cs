using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionsNavigationTabState : NavigationTabState
{
    private Action m_onTabExit;
    public Action OnTabExit => m_onTabExit;

    [SerializeField]
    private OptionsModuleState[] m_modulesNavigationStates = null;

    protected int m_positionIndex = 0;
    public int PositionIndex => m_positionIndex;

    public override void EnterState()
    {
        base.EnterState();
        m_positionIndex = 0;
    }

    public virtual void GoLeft()
    {
        if(m_modulesNavigationStates[m_positionIndex - 1] != null)
        {
            m_modulesNavigationStates[m_positionIndex - 1].GoLeft();
        }
    }

    public virtual void GoRight()
    {
        if (m_modulesNavigationStates[m_positionIndex - 1] != null)
        {
            m_modulesNavigationStates[m_positionIndex - 1].GoRight();
        }
    }

    public virtual void GoUp()
    {
        if(m_positionIndex > 0)
        {
            m_positionIndex--;
        }
        Debug.Log("UP : " + m_positionIndex);
        if (m_positionIndex > 0)
        {
            m_subStateMachine.SwitchToState(m_modulesNavigationStates[m_positionIndex - 1]);
        }
        else
        {
            m_subStateMachine.SwitchToState(null);
        }
        
    }

    public virtual void GoDown()
    {
        if(m_positionIndex < m_modulesNavigationStates.Length)
        {
            m_positionIndex++;
        }
        Debug.Log("DOWN : " + m_positionIndex);
        m_subStateMachine.SwitchToState(m_modulesNavigationStates[m_positionIndex - 1]);
    }

    public virtual void Back()
    {

    }

    public virtual void Confirm()
    {

    }
}
