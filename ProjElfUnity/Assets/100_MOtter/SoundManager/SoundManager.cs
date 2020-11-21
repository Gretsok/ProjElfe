using System.Collections.Generic;
using UnityEngine;

namespace MOtter.SoundManagement
{

    public class SoundManager : MonoBehaviour
    {
        #region Fields
        [SerializeField] private AudioSource m_originalAudioSource = null;
        private AudioSource[] m_audioSourcesPlaying = new AudioSource[0];
        private AudioSource[] m_audioSourcesNotPlaying = new AudioSource[0];
        #endregion

        #region Methods
        public AudioSource Play(AudioClip audioClip, bool loop = false, float volume = 1f)
        {
            AudioSource audioSource = GetAudioSourceToUse();
            audioSource.loop = loop;
            audioSource.clip = audioClip;
            audioSource.volume = volume;
            audioSource.name = audioClip.name;
            AddAudioSourceToPlayingArrays(audioSource);
            audioSource.Play();
            return audioSource;
        }

        public void PlayInSpace(AudioClip audioClip, Vector3 position, float volume = 1f)
        {
            AudioSource.PlayClipAtPoint(audioClip, position, volume);
        }

        public void Stop(AudioSource audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                AddAudioSourceToNotPlayingArrays(audioSource);
                RemoveAudioSourceToPlayingArrays(audioSource);
            }
        }


        #region ManageAudioSourcesArrays

        private AudioSource GetAudioSourceToUse()
        {
            if (m_audioSourcesNotPlaying.Length == 0)
            {
                AudioSource newAudioSource = Instantiate<AudioSource>(m_originalAudioSource, transform);
                AddAudioSourceToNotPlayingArrays(newAudioSource);
            }
            AudioSource audioSourceToReturn = m_audioSourcesNotPlaying[0];
            RemoveAudioSourceToNotPlayingArrays(audioSourceToReturn);
            return audioSourceToReturn;
        }

        public void CheckIfAudioSourcesPlayingStoppedPlaying()
        {
            List<AudioSource> audioSourcesToRemove = new List<AudioSource>();
            for (int i = 0; i < m_audioSourcesPlaying.Length; i++)
            {
                if (!m_audioSourcesPlaying[i].isPlaying)
                {
                    audioSourcesToRemove.Add(m_audioSourcesPlaying[i]);
                }
            }
            for (int i = 0; i < audioSourcesToRemove.Count; i++)
            {
                AddAudioSourceToNotPlayingArrays(audioSourcesToRemove[i]);
                RemoveAudioSourceToPlayingArrays(audioSourcesToRemove[i]);
            }
        }

        #region AudioSourcesPlaying
        private void AddAudioSourceToPlayingArrays(AudioSource audioSrc)
        {
            AudioSource[] tempAudioSources = m_audioSourcesPlaying;
            m_audioSourcesPlaying = new AudioSource[m_audioSourcesPlaying.Length + 1];
            for (int i = 0; i < m_audioSourcesPlaying.Length - 1; i++)
            {
                m_audioSourcesPlaying[i] = tempAudioSources[i];
            }
            m_audioSourcesPlaying[m_audioSourcesPlaying.Length - 1] = audioSrc;
        }

        private void RemoveAudioSourceToPlayingArrays(AudioSource audioSrc)
        {
            int indexOfAudioSrcToRemove = -1;
            for (int i = 0; i < m_audioSourcesPlaying.Length; i++)
            {
                if (m_audioSourcesPlaying[i].gameObject == audioSrc.gameObject)
                {
                    indexOfAudioSrcToRemove = i;
                }
            }
            if (indexOfAudioSrcToRemove == -1)
            {
                Debug.LogError("AudioSource to remove not found");
                return;
            }
            AudioSource[] tempAudioSources = m_audioSourcesPlaying;
            m_audioSourcesPlaying = new AudioSource[m_audioSourcesPlaying.Length - 1];
            for (int i = 0; i < indexOfAudioSrcToRemove; i++)
            {
                m_audioSourcesPlaying[i] = tempAudioSources[i];
            }
            for (int i = indexOfAudioSrcToRemove; i < m_audioSourcesPlaying.Length; i++)
            {
                m_audioSourcesPlaying[i] = tempAudioSources[i + 1];
            }
        }

        #endregion
        #region AudioSourcesNotPlaying
        private void AddAudioSourceToNotPlayingArrays(AudioSource audioSrc)
        {
            AudioSource[] tempAudioSources = m_audioSourcesNotPlaying;
            m_audioSourcesNotPlaying = new AudioSource[m_audioSourcesNotPlaying.Length + 1];
            for (int i = 0; i < m_audioSourcesNotPlaying.Length - 1; i++)
            {
                m_audioSourcesNotPlaying[i] = tempAudioSources[i];
            }
            m_audioSourcesNotPlaying[m_audioSourcesNotPlaying.Length - 1] = audioSrc;
        }
        private void RemoveAudioSourceToNotPlayingArrays(AudioSource audioSrc)
        {
            int indexOfAudioSrcToRemove = -1;
            for (int i = 0; i < m_audioSourcesNotPlaying.Length; i++)
            {
                if (m_audioSourcesNotPlaying[i].gameObject == audioSrc.gameObject)
                {
                    indexOfAudioSrcToRemove = i;
                }
            }
            if (indexOfAudioSrcToRemove == -1)
            {
                Debug.LogError("AudioSource to remove not found");
                return;
            }
            AudioSource[] tempAudioSources = m_audioSourcesNotPlaying;
            m_audioSourcesNotPlaying = new AudioSource[m_audioSourcesNotPlaying.Length - 1];
            for (int i = 0; i < indexOfAudioSrcToRemove; i++)
            {
                m_audioSourcesNotPlaying[i] = tempAudioSources[i];
            }
            for (int i = indexOfAudioSrcToRemove; i < m_audioSourcesNotPlaying.Length; i++)
            {
                m_audioSourcesNotPlaying[i] = tempAudioSources[i + 1];
            }
        }
        #endregion
        #endregion
        #endregion
    }
}