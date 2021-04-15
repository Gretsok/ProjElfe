using MOtter.PlayersManagement;
using MOtter.StatesMachine;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlowTest : MainStatesMachine
{
    [SerializeField]
    private UIWidgetTest m_widgetTest = null;

    public override IEnumerator LoadAsync()
    {

        yield return null;
        MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.AddNewPlayer();
        m_widgetTest.Init();
        

        yield return base.LoadAsync();
    }

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        IInputActionCollection actions = MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetActions(0);
        if(actions is PlayerInputsActions)
        {
            Debug.Log("On se fout de ma gueule");
        }
        PlayerInputsActions playerActions = (PlayerInputsActions) actions;
        (MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetActions(0) as PlayerInputsActions).Generic.Jump.performed += Jump_performed;
    }

    private void Jump_performed(InputAction.CallbackContext obj)
    {
        Debug.Log("Jump");
    }


    internal override void ExitStateMachine()
    {
        (MOtter.MOtterApplication.GetInstance().PLAYERPROFILES.GetActions(0) as PlayerInputsActions).Generic.Jump.performed -= Jump_performed;
        base.ExitStateMachine();
    }
}
