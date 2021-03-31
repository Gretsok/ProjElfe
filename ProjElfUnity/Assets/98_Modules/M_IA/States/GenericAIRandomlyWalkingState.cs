

namespace ProjElf.AI
{
    public class GenericAIRandomlyWalkingState : GenericAIWalkingState
    {
        bool m_reachedDestination = false;

        public override void EnterState()
        {
            base.EnterState();
            SetNewLocationToGo();
        }


        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if ((m_owner.transform.position - m_currentLocationToGo).magnitude < m_distanceToCurrentLocationToGoToChangeLocationToGo && !m_reachedDestination)
            {
                m_reachedDestination = true;
                OnDestinationReached();
            }
        }

        protected virtual void OnDestinationReached()
        {
            SetNewLocationToGo();
        }

        protected virtual void SetNewLocationToGo()
        {
            m_currentLocationToGo = GetRandomLocationToGo();
            m_owner.Agent.SetDestination(m_currentLocationToGo);
            m_reachedDestination = false;
        }
    }
}