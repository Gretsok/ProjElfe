using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ProjElf.AI
{
    public class GenericAIWalkingState : GenericAIState
    {
        protected Vector3 m_currentLocationToGo = Vector3.zero;
        [SerializeField]
        protected Vector2 m_rangeDistanceBetweenTwoLocations = Vector2.zero;
        [SerializeField]
        protected float m_distanceToCurrentToGoToChangeLocationToGo = 1f;

        public override void EnterState()
        {
            base.EnterState();
            SetNewLocationToGo();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if((m_owner.transform.position - m_currentLocationToGo).magnitude < m_distanceToCurrentToGoToChangeLocationToGo)
            {
                SetNewLocationToGo();
            }
        }

        protected void SetNewLocationToGo()
        {
            m_currentLocationToGo = GetRandomLocationToGo();
            m_owner.Agent.SetDestination(m_currentLocationToGo);
        }

        protected Vector3 GetRandomLocationToGo()
        {
            // Getting Random Direction
            Random.InitState((int) Time.time * gameObject.GetHashCode());
            Vector2 m_random2DDirection = Random.insideUnitCircle;
            Random.InitState((int)(Time.time/2.58 * gameObject.GetHashCode()));
            float distanceFromActualPosition = Random.Range(m_rangeDistanceBetweenTwoLocations.x, m_rangeDistanceBetweenTwoLocations.y);
            Vector3 randomDirection = new Vector3(m_random2DDirection.x, 0, m_random2DDirection.y) * distanceFromActualPosition;

            randomDirection += m_owner.transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, distanceFromActualPosition, 1);
            Vector3 finalPosition = hit.position;

            return finalPosition;
        }
    }
}