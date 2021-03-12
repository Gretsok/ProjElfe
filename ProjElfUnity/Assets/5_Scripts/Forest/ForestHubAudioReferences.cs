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


        [SerializeField]
        private SoundData m_ambiance = null;

        public static SoundData Ambiance => s_instance.m_ambiance;
    }
}