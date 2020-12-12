using MOtter.StatesMachine;
using ProjElf.PlayerController;
using UnityEngine;

public class ProjElfGameMode : PauseableStateMachine
{
    [SerializeField]
    private Player m_player = null;
    protected override void EnterStateMachine()
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

    protected override void ExitStateMachine()
    {
        m_player.CleanUp();
        base.ExitStateMachine();
    }
}
