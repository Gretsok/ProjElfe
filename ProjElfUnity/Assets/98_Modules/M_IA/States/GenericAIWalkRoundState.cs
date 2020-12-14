using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.AI
{
    public class GenericAIWalkRoundState : GenericAIWalkingState
    {
        [SerializeField]
        private List<Vector3> m_walkLocations = new List<Vector3>();
        [SerializeField]
        private int m_numberOfLocationsInWalk = 2;
        private int m_locationIndex = 0;

        public override void EnterState()
        {
            base.EnterState();
            m_currentLocationToGo = GetRandomLocationToGo();
            m_walkLocations.Add(m_currentLocationToGo);
            m_owner.Agent.SetDestination(m_currentLocationToGo);
        }

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            if ((m_owner.transform.position - m_currentLocationToGo).magnitude < m_distanceToCurrentToGoToChangeLocationToGo)
            {
                GoToNextLocation();
            }
        }

        private void GoToNextLocation()
        {
            m_locationIndex = (m_locationIndex + 1) % m_numberOfLocationsInWalk;
            while(m_locationIndex >= m_walkLocations.Count)
            {
                m_walkLocations.Add(GetRandomLocationToGo());
            }
            m_currentLocationToGo = m_walkLocations[m_locationIndex];
            m_owner.Agent.SetDestination(m_currentLocationToGo);
        }
    }
}