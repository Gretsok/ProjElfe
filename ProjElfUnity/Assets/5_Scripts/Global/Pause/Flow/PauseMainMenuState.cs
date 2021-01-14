using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMainMenuState : PauseState
{
    private PauseMainMenuPanel m_mainMenuPanel = null;
    private ButtonNavigationPosition m_currentPosition = null;
    public override void EnterState()
    {
        base.EnterState();
        m_mainMenuPanel = GetPanel<PauseMainMenuPanel>();
        SwitchToPosition(m_mainMenuPanel.ContinueButton);
    }

    public override void GoDown()
    {
        base.GoDown();
        SwitchToPosition(m_mainMenuPanel.BackToMenuButton);
    }

    public override void GoLeft()
    {
        base.GoLeft();
        SwitchToPosition(m_mainMenuPanel.OptionsButton);
    }

    public override void GoRight()
    {
        base.GoRight();
        SwitchToPosition(m_mainMenuPanel.QuitGameButton);
    }

    public override void GoUp()
    {
        base.GoUp();
        SwitchToPosition(m_mainMenuPanel.ContinueButton);
    }

    private void SwitchToPosition(ButtonNavigationPosition position)
    {
        m_currentPosition?.OnUnselected();
        m_currentPosition = position;
        m_currentPosition?.OnSelected();
    }
}
