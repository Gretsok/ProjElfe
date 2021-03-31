using UnityEngine;
using ProjElf.AI;

namespace ProjElf.HubForest
{

    public class AnimalHubRandomlyWalking : GenericAIRandomlyWalkingState
    {

        protected override Vector3 GetRandomLocationToGo()
        {
            return base.GetRandomLocationToGo();/*
        Vector3 randomDirection = Random.insideUnitSphere * 3f;

        randomDirection += m_owner.transform.position;
        NavMeshHit hit;
        NavMesh.SamplePosition(randomDirection, out hit, 3f, 1);
        return hit.position;*/
        }

        protected override void OnDestinationReached()
        {
            m_owner.SwitchToState((m_owner as AnimalHubController).WaitingState);
        }
    }
}