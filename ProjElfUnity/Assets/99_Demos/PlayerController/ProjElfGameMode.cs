using MOtter;
using MOtter.StatesMachine;
using ProjElf.PlayerController;
using System;
using System.Collections;
using UnityEngine;

public class ProjElfGameMode : PauseableStateMachine, IProjElfMainStateMachine
{
    [SerializeField]
    protected Player m_player = null;
    public Player Player => m_player;

    protected PlayerInputsActions m_actions = null;
    public PlayerInputsActions Actions => m_actions;

    internal override void EnterStateMachine()
    {
        base.EnterStateMachine();
        Cursor.visible = false;
        m_player.Init();
    }
    public override void DoUpdate()
    {
        base.DoUpdate();
        m_player.DoUpdate();
    }

    public override void DoFixedUpdate()
    {
        base.DoFixedUpdate();
        m_player.DoFixedUpdate();
    }

    public override void DoLateUpdate()
    {
        base.DoLateUpdate();
        m_player.DoLateUpdate();
    }

    internal override void ExitStateMachine()
    {
        MOtterApplication.GetInstance().GAMEMANAGER.SaveDataManager.SaveSaveDataManager();
        m_player.CleanUp();
        base.ExitStateMachine();
    }


}
