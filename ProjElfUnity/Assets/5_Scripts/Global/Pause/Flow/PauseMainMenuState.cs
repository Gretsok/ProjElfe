using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMainMenuState : PauseState
{
    private PauseMainMenuPanel m_mainMenuPanel = null;
    [SerializeField]
    protected ProjElfPauseStateMachine m_pauseStateMachine = null;

    public override void EnterState()
    {
        base.EnterState();
    }


}
