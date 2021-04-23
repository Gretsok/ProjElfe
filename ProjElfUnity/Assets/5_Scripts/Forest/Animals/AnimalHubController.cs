using UnityEngine;
using ProjElf.AI;
using ProjElf.AnimalManagement;
using UnityEngine.AI;

namespace ProjElf.HubForest
{
    public class AnimalHubController : GenericAI
    {
        [SerializeField]
        private Transform m_animalContainer = null;
        private Animal m_animal = null;
        public Animal Animal => m_animal;

        [Header("States")]
        [SerializeField]
        private AnimalHubRandomlyWalking m_walkingState = null;
        [SerializeField]
        private AnimalHubWaitingState m_waitingState = null;

        public AnimalHubRandomlyWalking WalkingState => m_walkingState;
        public AnimalHubWaitingState WaitingState => m_waitingState;

        public void Init(AnimalData animalData)
        {
            base.Init();
            m_animal = animalData.InstantiateAnimal(m_animalContainer.position, m_animalContainer.rotation, m_animalContainer);
            Vector3 randomDirection = Random.insideUnitSphere * 5f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 5f, 1);
            transform.position = hit.position;
        }

    }
}