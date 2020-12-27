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


    public bool GoLeft()
    {
        if (m_currentState != null)
        {
            (m_currentState as OptionsNavigationTabState).GoLeft();
            return true;
        }
        return false;
    }

    public bool GoRight()
    {
        if(m_currentState != null)
        {
            (m_currentState as OptionsNavigationTabState).GoRight();
            return true;
        }
        return false;
    }

    public void GoUp()
    {
        if(m_currentState != null)
        { }
    }

    public void GoDown()
    {

    }
}
