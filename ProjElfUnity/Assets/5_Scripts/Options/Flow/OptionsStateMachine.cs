using MOtter.StatesMachine;
using UnityEngine;

public class OptionsStateMachine : StatesMachine
{
    [SerializeField]
    private ConfigurationOptionsState m_configurationState = null;
    [SerializeField]
    private GameplayOptionsState m_gameplayState = null;

    public ConfigurationOptionsState ConfigurationState => m_configurationState;
    public GameplayOptionsState GameplayState => m_gameplayState;


    public void GoLeft()
    {
        if (m_currentState != null)
        {
            if((m_currentState as OptionsNavigationTabState).PositionIndex == 0)
            {
                SwitchToState(m_configurationState);
            }
            else
            {
                (m_currentState as OptionsNavigationTabState).GoLeft();
            }
        }
    }

    public void GoRight()
    {
        if(m_currentState != null)
        {
            if ((m_currentState as OptionsNavigationTabState).PositionIndex == 0)
            {
                SwitchToState(m_gameplayState);
            }
            else
            {
                (m_currentState as OptionsNavigationTabState).GoRight();
            }
        }
    }

    public void GoUp()
    {
        if(m_currentState != null)
        {
            (m_currentState as OptionsNavigationTabState).GoUp();
        }
    }

    public void GoDown()
    {
        if (m_currentState != null)
        {
            (m_currentState as OptionsNavigationTabState).GoDown();
        }
    }

    public void Back()
    {

    }
}
