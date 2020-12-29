using MOtter;
using MOtter.StatesMachine;
using ProjElf.PlayerController;
using ProjElf.ProceduraleGeneration;

public class DemoDunjeonGameplayState : State
{
    private DunjeonGameMode m_gamemode = null;
    private Player m_player = null;

    private void Start()
    {
        m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
    }

    public override void EnterState()
    {
        base.EnterState();
        m_player = m_gamemode.Player;
        m_player.Init();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        m_player.DoUpdate();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        m_player.DoFixedUpdate();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();
        m_player.DoLateUpdate();
    }

    public override void ExitState()
    {
        m_player.CleanUp();
        base.ExitState();
    }
}
