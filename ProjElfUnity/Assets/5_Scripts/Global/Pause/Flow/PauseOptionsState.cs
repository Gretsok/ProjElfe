using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseOptionsState : PauseMainMenuState
{
    private ProjElfGameMode m_gamemode = null;


    public override void EnterState()
    {
        base.EnterState();
        m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();
        m_gamemode.Actions.Enable();
        m_gamemode.Actions.UI.Back.performed += Back_performed;
    }

    private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        m_pauseStateMachine.GoToPauseMenu();
    }

    public override void ExitState()
    {
        m_gamemode.Actions.UI.Back.performed -= Back_performed;
        base.ExitState();
    }
}
