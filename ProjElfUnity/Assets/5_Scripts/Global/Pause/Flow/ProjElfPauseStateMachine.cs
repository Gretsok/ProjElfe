using MOtter;
using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjElfPauseStateMachine : StatesMachine
{
    private ProjElfGameMode m_gamemode = null;
    [SerializeField]
    private Panel m_pausePanel = null;

    private void Start()
    {
        m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();
    }

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        m_pausePanel.Show();
        SetUpInputs();
    }

    internal override void ExitStateMachine()
    {
        m_pausePanel.Hide();
        CleanUpInputs();
        base.ExitStateMachine();
    }

    #region Inputs
    public void SetUpInputs()
    {
        m_gamemode.Actions.Enable();
        m_gamemode.Actions.UI.Back.performed += Back_performed;
        m_gamemode.Actions.UI.MoveDown.performed += MoveDown_performed;
        m_gamemode.Actions.UI.MoveUp.performed += MoveUp_performed;
        m_gamemode.Actions.UI.MoveLeft.performed += MoveLeft_performed;
        m_gamemode.Actions.UI.MoveRight.performed += MoveRight_performed;
        m_gamemode.Actions.UI.Confirm.performed += Confirm_performed;
    }

    private void Confirm_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        throw new System.NotImplementedException();
    }

    private void MoveRight_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        (m_currentState as PauseState).GoRight();
    }

    private void MoveLeft_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        (m_currentState as PauseState).GoLeft();
    }

    private void MoveUp_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        (m_currentState as PauseState).GoUp();
    }

    private void MoveDown_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        (m_currentState as PauseState).GoDown();
    }

    private void Back_performed(UnityEngine.InputSystem.InputAction.CallbackContext obj)
    {
        m_gamemode.Unpause();
    }

    public void CleanUpInputs()
    {
        m_gamemode.Actions.UI.Back.performed -= Back_performed;
        m_gamemode.Actions.UI.MoveDown.performed -= MoveDown_performed;
        m_gamemode.Actions.UI.MoveUp.performed -= MoveUp_performed;
        m_gamemode.Actions.UI.MoveLeft.performed -= MoveLeft_performed;
        m_gamemode.Actions.UI.MoveRight.performed -= MoveRight_performed;
        m_gamemode.Actions.UI.Confirm.performed -= Confirm_performed;
        m_gamemode.Actions.Disable();
    }
    #endregion
}
