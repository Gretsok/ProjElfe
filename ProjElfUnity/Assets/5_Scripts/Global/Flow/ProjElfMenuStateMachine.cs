using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjElfMenuStateMachine : MainStatesMachine, IProjElfMainStateMachine
{
    protected PlayerInputsActions m_actions = null;
    public PlayerInputsActions Actions => m_actions;
}
