using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MOtter.SoundManagement
{
    [CreateAssetMenu(fileName = "SoundData", menuName = "Sound/SoundData")]
    public class SoundData : ScriptableObject
    {
        [SerializeField]
        private AudioClip m_audioClip = null;

        [SerializeField]
        private ESoundCategoryName m_categoryName = ESoundCategoryName.SFX;

        public AudioClip AudioClip => m_audioClip;
        public ESoundCategoryName CategoryName => m_categoryName;
    }
}