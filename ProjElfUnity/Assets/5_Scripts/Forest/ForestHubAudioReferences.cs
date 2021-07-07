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
    }
}