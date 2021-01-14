using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ProjElf.AI
{
    public class GenericAIWalkingState : GenericAIState
    {

        protected Vector3 m_currentLocationToGo = Vector3.zero;
        [SerializeField, Tooltip("Only works when no dunjeon room is associated to this AI")]
        protected Vector2 m_rangeDistanceBetweenTwoLocations = Vector2.zero;
        [SerializeField]
        protected float m_distanceToCurrentLocationToGoToChangeLocationToGo = 1f;
        [Header("If close enough to player")]
        [SerializeField]
        private float m_sqrDistanceToPlayerToSwitch = 5f;
        [SerializeField]
        private GenericAIState m_stateWhenPlayerClose = null;

        public override void LateUpdateState()
        {
            base.LateUpdateState();
            ManageStateToActivate();
        }

        protected Vector3 GetRandomLocationToGo()
        {
            if(m_owner.AttachedDunjeonRoom != null)
            {
                Debug.Log("ATTACHED DUNJEON ROOM");
                return m_owner.AttachedDunjeonRoom.GetRandomWalkablePoint();
            }
            else
            {
                Debug.Log("NO PUTIAN DE FUCKING ATTACHED DUNJEON ROOM");
                // Getting Random Direction
                Random.InitState((int)Time.time * gameObject.GetHashCode());
                Vector2 m_random2DDirection = Random.insideUnitCircle;
                Random.InitState((int)(Time.time / 2.58 * gameObject.GetHashCode()));
                float distanceFromActualPosition = Random.Range(m_rangeDistanceBetweenTwoLocations.x, m_rangeDistanceBetweenTwoLocations.y);
                Vector3 randomDirection = new Vector3(m_random2DDirection.x, 0, m_random2DDirection.y) * distanceFromActualPosition;

                randomDirection += m_owner.transform.position;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, distanceFromActualPosition, 1);
                Vector3 finalPosition = hit.position;
                return finalPosition;
            }
        }

        public void ManageStateToActivate()
        {
            if((m_owner.Player.transform.position - m_owner.transform.position).sqrMagnitude < m_sqrDistanceToPlayerToSwitch)
            {
                m_owner.SwitchToState(m_stateWhenPlayerClose);
            }
        }
    }
}