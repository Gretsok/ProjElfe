using UnityEngine;

namespace ProjElf.AnimalManagement
{
    public class Animal : MonoBehaviour
    {
        public AnimalData AnimalData { get; internal set; }
        [SerializeField]
        private AnimalAnimationsHandler m_animationsHandler = null;
        public AnimalAnimationsHandler AnimationsHandler => m_animationsHandler;
    }
}