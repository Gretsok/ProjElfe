using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.AI
{
    public class GenericAIGettingCloserToPlayerState : GenericAIState
    {
        [SerializeField]
        private float m_sqrDistanceToStopFollowPlayer = 900f;
        public override void LateUpdateState()
        {
            base.LateUpdateState();
            m_owner.Agent.SetDestination(m_owner.Player.transform.position);
            if((m_owner.transform.position - m_owner.Player.transform.position).sqrMagnitude > m_sqrDistanceToStopFollowPlayer)
            {
                m_owner.SwitchToPreviousState();
            }
            
        }
    }
}