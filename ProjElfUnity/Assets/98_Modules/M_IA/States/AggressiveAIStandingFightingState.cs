﻿using ProjElf.AI;
using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AggressiveAIStandingFightingState : GenericAIState
{
    [SerializeField]
    private float m_sqrDistanceFromPlayerComingCloser = 0f;
    [SerializeField]
    private GenericAIState m_playerComingCloserAction = null;
    [SerializeField]
    private float m_sqrDistanceFromPlayerGoingFurther = 0f;
    [SerializeField]
    private GenericAIState m_playerGoingFurtherAction = null;

    public override void EnterState()
    {
        base.EnterState();
        m_owner.Agent.SetDestination(m_owner.transform.position);
        (m_owner as AggressiveAI).CombatController.StartUseWeapon();
    }

    public override void LateUpdateState()
    {
        base.LateUpdateState();
        m_owner.transform.LookAt(m_owner.Player.transform.position);
        if ((m_owner.transform.position - m_owner.Player.transform.position).sqrMagnitude < m_sqrDistanceFromPlayerComingCloser)
        {
            m_owner.SwitchToState(m_playerComingCloserAction);
        }

        if ((m_owner.transform.position - m_owner.Player.transform.position).sqrMagnitude > m_sqrDistanceFromPlayerGoingFurther)
        {
            m_owner.SwitchToState(m_playerGoingFurtherAction);
        }
    }
    public override void ExitState()
    {
        (m_owner as AggressiveAI).CombatController.StopUseWeapon();
        base.ExitState();
    }

}