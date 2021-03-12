using System.Collections.Generic;
using UnityEngine;

namespace MOtter.SoundManagement
{
    public class SoundManager : MonoBehaviour
    {
        private float m_musicVolume = 1f;
        private float m_sfxVolume = 1f;

        [SerializeField, Tooltip("")]
        private AudioSource m_audioSource = null;

        private List<AudioSource> m_audioSourcesPool = new List<AudioSource>();

        public AudioSource Play2DSound(SoundData soundData, bool loop = false, float volume = 1f)
        {
            AudioSource audioSource = GetAudioSource();
            audioSource.loop = loop;
            audioSource.clip = soundData.AudioClip;
            audioSource.volume = Mathf.Clamp01(volume) * GetVolume(soundData.CategoryName);
            audioSource.name = soundData.AudioClip.name;
            audioSource.spatialBlend = 0f;
            audioSource.Play();
            return audioSource;
        }

        public AudioSource Play3DSound(SoundData soundData, Vector3 position, bool loop = false, float volume = 1f, Transform parent = null, float spatialBlend = 0.7f)
        {
            AudioSource audioSource = GetAudioSource();
            audioSource.loop = loop;
            audioSource.clip = soundData.AudioClip;
            audioSource.volume = Mathf.Clamp01(volume) * GetVolume(soundData.CategoryName);
            audioSource.name = soundData.AudioClip.name;
            audioSource.transform.position = position;
            audioSource.spatialBlend = 0.7f;
            if (parent != null)
            {
                audioSource.transform.SetParent(parent);
            }
            audioSource.Play();
            return audioSource;
        }

        public void CleanSource(AudioSource audioSource)
        {
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
            }
            if(!m_audioSourcesPool.Contains(audioSource))
            {
                m_audioSourcesPool.Add(audioSource);
            }
        }

        public AudioSource GetAudioSource()
        {
            AudioSource audioSource = null;

            if(m_audioSourcesPool.Count > 0)
            {
                audioSource = m_audioSourcesPool[0];
                m_audioSourcesPool.Remove(audioSource);
            }
            else
            {
                audioSource = Instantiate(m_audioSource, this.transform);
            }

            return audioSource;
        }


        #region Volume Management
        public float GetVolume(ESoundCategoryName soundCategory)
        {
            switch(soundCategory)
            {
                case ESoundCategoryName.Music:
                    return m_musicVolume;
                case ESoundCategoryName.SFX:
                    return m_sfxVolume;
                default:
                    Debug.LogError("Invalid sound category");
                    return -1f;
            }
        }

        public void SetVolume(float volume, ESoundCategoryName soundCategory)
        {
            switch (soundCategory)
            {
                case ESoundCategoryName.Music:
                    m_musicVolume = Mathf.Clamp01(volume);
                    break;
                case ESoundCategoryName.SFX:
                    m_sfxVolume = Mathf.Clamp01(volume);
                    break;
                default:
                    Debug.LogError("Invalid sound category");
                    break;
            }
        }
        #endregion

    }

    public enum ESoundCategoryName
    {
        Music,
        SFX
    }
}