using MOtter.SoundManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace ProjElf.HubForest
{
    public class ForestHubAudioReferences : MonoBehaviour
    {
        private static ForestHubAudioReferences s_instance = null;

        private void Awake()
        {
            s_instance = this;
        }

        public static ForestHubAudioReferences Instance => s_instance;

        [SerializeField]
        private SoundData m_ambiance = null;
        [SerializeField]
        private SoundData m_music = null;

        [SerializeField]
        private SoundData m_openChest = null;
        [SerializeField]
        private SoundData m_closeChest = null;
        [SerializeField]
        private SoundData m_openBook = null;
        [SerializeField]
        private SoundData m_closeBook = null;

        private AudioSource m_ambianceAudioSource = null;
        private AudioSource m_musicAudioSource = null;

        public void StartHubMusic()
        {
            m_musicAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(m_music, true);
        }
        public void StopHubMusic()
        {
            if(m_musicAudioSource != null && m_musicAudioSource.isPlaying)
            {
                m_musicAudioSource.Stop();
            }
        }

        public void StartHubAmbiance()
        {
            m_ambianceAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(m_ambiance, true);
        }
        public void StopHubAmbiance()
        {
            if (m_ambianceAudioSource != null && m_ambianceAudioSource.isPlaying)
            {
                m_ambianceAudioSource.Stop();
            }
        }

        public void PlayOpenChestSound(Vector3 position)
        {
            MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_openChest, position);
        }

        public void PlayCloseChestSound(Vector3 position)
        {
            MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_closeChest, position);
        }

        public void PlayOpenBookSound(Vector3 position)
        {
            MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_openBook, position);
        }

        public void PlayCloseBookSound(Vector3 position)
        {
            MOtter.MOtterApplication.GetInstance().SOUND.Play3DSound(m_closeBook, position);
        }
    }
}