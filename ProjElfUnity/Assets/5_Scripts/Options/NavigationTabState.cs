using MOtter.StatesMachine;
using UnityEngine;

public class NavigationTabState : NavigationState
{
    [SerializeField]
    protected StatesMachine m_subStateMachine = null;

    public override void EnterState()
    {
        base.EnterState();
        m_subStateMachine.EnterStateMachine();
    }

    public override void UpdateState()
    {
        base.UpdateState();
        m_subStateMachine.DoUpdate();
    }

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        m_subStateMachine.DoFixedUpdate();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();
        m_subStateMachine.DoLateUpdate();
    }

    public override void ExitState()
    {
        m_subStateMachine.ExitStateMachine();
        base.ExitState();
    }
}
