using MOtter;
using MOtter.StatesMachine;
using UnityEngine;

public class IntroDemoInputState : UIState
{
    private float timeOfStart = 0;
    public float durationToWait = 10f;

    public override void EnterState()
    {
        base.EnterState();
        timeOfStart = Time.time;
    }

    public override void UpdateState()
    {
        base.UpdateState();
        if(Time.time - timeOfStart > durationToWait)
        {
            MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<InputDemoGameMode>().SwitchToNextState();
        }
    }

    public override void ExitState()
    {
        Debug.Log("CAN TEST");
        base.ExitState();
    }
}
