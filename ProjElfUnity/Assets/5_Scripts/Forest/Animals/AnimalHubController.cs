using UnityEngine;
using ProjElf.AI;
using ProjElf.AnimalManagement;
using UnityEngine.AI;
using MOtter.SoundManagement;

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

        [SerializeField]
        private SoundData m_animalSoundData = null;
        private AudioSource m_animalSound = null;

        public void Init(AnimalData animalData)
        {
            base.Init();
            m_animal = animalData.InstantiateAnimal(m_animalContainer.position, m_animalContainer.rotation, m_animalContainer);
            Vector3 randomDirection = Random.insideUnitSphere * 5f;
            randomDirection += transform.position;
            NavMeshHit hit;
            NavMesh.SamplePosition(randomDirection, out hit, 5f, 1);
            transform.position = hit.position;
            m_animalSound = MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_animalSoundData, transform.position, true, 1, transform);
        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
            m_animalSound.Stop();
        }

    }
}