using ProjElf.AI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericAIFleeFromPlayerState : GenericAIState
{
    [SerializeField]
    private float m_sqrDistanceFromPlayerComingCloser = 0f;
    [SerializeField]
    private GenericAIState m_playerComingCloserAction = null;
    [SerializeField]
    private float m_sqrDistanceFromPlayerGoingFurther = 0f;
    [SerializeField]
    private GenericAIState m_playerGoingFurtherAction = null;

    public override void LateUpdateState()
    {
        base.LateUpdateState();
        // AI fleeing from player
        Vector3 localPlayerPosition = transform.InverseTransformPoint(m_owner.Player.transform.position);
        Vector3 destination = transform.TransformPoint(-localPlayerPosition);
        m_owner.Agent.SetDestination(destination);

        // Exit state conditions
        if ((m_owner.transform.position - m_owner.Player.transform.position).sqrMagnitude < m_sqrDistanceFromPlayerComingCloser)
        {
            m_owner.SwitchToState(m_playerComingCloserAction);
        }

        if ((m_owner.transform.position - m_owner.Player.transform.position).sqrMagnitude > m_sqrDistanceFromPlayerGoingFurther)
        {
            m_owner.SwitchToState(m_playerGoingFurtherAction);
        }
    }
}
