using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class AdventurePortal : MonoBehaviour, IInteractable
    {
        private HubForestGameMode m_gamemode = null;

        #region Sounds refs
        [SerializeField]
        private MOtter.SoundManagement.SoundData m_portalSoundData = null;
        [SerializeField]
        private float m_soundHeightPosition = 2f;
        private AudioSource m_portalAudioSource = null;
        #endregion

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
            m_portalAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_portalSoundData, transform.position + Vector3.up * 2, true, 10f);
        }
        public void DoInteraction(Interactor interactor = null)
        {
            Debug.Log("Interact with portal");
            
        }

        public void StartBeingWatched(Interactor iteractor)
        {
            Debug.Log("Portal start being watched");
        }

        public void StopBeingWatched(Interactor iteractor)
        {
            Debug.Log("Portal stop being watched");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject == m_gamemode.Player.gameObject)
                m_gamemode.ActivateDunjeonSelectionState();
        }


#if UNITY_EDITOR
        private void OnValidate()
        {
            if (m_portalAudioSource != null && m_portalAudioSource.isPlaying)
            {
                m_portalAudioSource.transform.position = transform.position + Vector3.up * m_soundHeightPosition;
            }
        }
#endif
        private void OnDestroy()
        {
            if(m_portalAudioSource != null && m_portalAudioSource.isPlaying)
            {
                m_portalAudioSource.Stop();
            }
        }
    }
}