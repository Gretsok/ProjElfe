

namespace ProjElf.AI
{
    public class GenericAIRandomlyWalkingState : GenericAIWalkingState
    {

        public override void EnterState()
        {
            base.EnterState();
            SetNewLocationToGo();
        }


        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if ((m_owner.transform.position - m_currentLocationToGo).magnitude < m_distanceToCurrentToGoToChangeLocationToGo)
            {
                SetNewLocationToGo();
            }
        }


        protected void SetNewLocationToGo()
        {
            m_currentLocationToGo = GetRandomLocationToGo();
            m_owner.Agent.SetDestination(m_currentLocationToGo);
        }
    }
}