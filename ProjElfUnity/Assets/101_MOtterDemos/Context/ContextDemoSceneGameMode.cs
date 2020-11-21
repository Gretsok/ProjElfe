using MOtter;
using MOtter.Context;
using MOtter.StatesMachine;
using System.Collections.Generic;
using UnityEngine;

public class ContextDemoSceneGameMode : MainStatesMachine
{
    public List<string> contextStates = new List<string>();
    public List<int> contextStatesHash = new List<int>();

    public ContextDemoDisplayData displayer = null;

    public override void EnterStateMachine()
    {
        base.EnterStateMachine();

        InitHash();
        CreateContexts();
    }

    private void CreateContexts()
    {
        MOtterApplication.GetInstance().CONTEXT.RegisterNewContext(new StatedContext(contextStatesHash[0], "zoneTile"));
        MOtterApplication.GetInstance().CONTEXT.RegisterNewContext(new BooleanContext(false, "detectingGround"));
    }

    private void InitHash()
    {
        foreach(string stateName in contextStates)
        {
            contextStatesHash.Add(MOtterApplication.GetInstance().UTILS.GetDeterministicHashCode(stateName));
        }
    }
    public override void DoUpdate()
    {
        base.DoUpdate();
        int contextValue = MOtterApplication.GetInstance().CONTEXT.GetContext<StatedContext>("zoneTile").Value;
        for(int i = 0; i < contextStatesHash.Count; i++)
        {
            if(contextValue == contextStatesHash[i])
            {
                displayer.ChangeZoneName(contextStates[i]);
            }
        }
        displayer.ChangeDetectionGroundDisplay(MOtterApplication.GetInstance().CONTEXT.GetContext<BooleanContext>("detectingGround").Value);
    }

    public override void ExitStateMachine()
    {

        base.ExitStateMachine();
    }
}
