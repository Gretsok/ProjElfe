using UnityEngine;
using UnityEngine.EventSystems;

public class PauseMainMenuState : PauseState
{
    private PauseMainMenuPanel m_mainMenuPanel = null;
    [SerializeField]
    protected ProjElfPauseStateMachine m_pauseStateMachine = null;
    [SerializeField]
    private GameObject m_firstSelectedObject = null;

    public override void EnterState()
    {
        EventSystem.current.SetSelectedGameObject(m_firstSelectedObject);
        base.EnterState();
    }


}
