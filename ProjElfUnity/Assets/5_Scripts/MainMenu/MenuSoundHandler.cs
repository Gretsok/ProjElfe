using MOtter.SoundManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class MenuSoundHandler : MonoBehaviour
    {
        [SerializeField]
        private MOtter.SoundManagement.SoundData m_musicSoundData = null;
        [SerializeField]
        private MOtter.SoundManagement.SoundData m_ambianceSoundData = null;
        [SerializeField]
        private MOtter.SoundManagement.SoundData m_moveSoundData = null;
        [SerializeField]
        private MOtter.SoundManagement.SoundData m_subMoveSoundData = null;


        private AudioSource m_musicAudioSource = null;
        private AudioSource m_ambianceAudioSource = null;


        private SoundManager m_soundManager = null;

        private void Start()
        {
            m_soundManager = MOtter.MOtterApplication.GetInstance().SOUND;
        }

        public void StartMenuMusic()
        {
            m_musicAudioSource = m_soundManager.Play2DSound(m_musicSoundData, true);
        }

        public void StopMenuMusic()
        {
            m_musicAudioSource.Stop();
        }

        public void PlayMoveSound()
        {
            m_soundManager.Play2DSound(m_moveSoundData);
        }

        public void PlaySubMoveSound()
        {
            m_soundManager.Play2DSound(m_subMoveSoundData);
        }
    }
}