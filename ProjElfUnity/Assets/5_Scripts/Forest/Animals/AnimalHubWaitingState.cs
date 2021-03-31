using UnityEngine;
using ProjElf.AI;

namespace ProjElf.HubForest
{
    public class AnimalHubWaitingState : GenericAIState
    {
        [SerializeField]
        private Vector2 m_durationToWaitRange = Vector2.zero;
        private float m_durationToWait = float.MinValue;
        private float m_timeEnteredState = float.MinValue;

        private bool m_finishWaiting = false;

        public override void EnterState()
        {
            base.EnterState();
            m_timeEnteredState = Time.time;
            m_durationToWait = Random.Range(m_durationToWaitRange.x, m_durationToWaitRange.y);
            m_finishWaiting = false;
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if (Time.time - m_timeEnteredState > m_durationToWait && !m_finishWaiting)
            {
                m_owner.SwitchToState((m_owner as AnimalHubController).WalkingState);
                m_finishWaiting = true;
            }
        }
    }
}