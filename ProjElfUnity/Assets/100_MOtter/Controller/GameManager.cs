using UnityEngine;

namespace MOtter.StatesMachine
{
    public class GameManager : MonoBehaviour
    {
        private MainStatesMachine m_mainStatesMachine = null;

        private void Start()
        {
            //MOtterApplication.GetInstance().PLAYERPROFILES.Init();
        }

        private void Update()
        {
            if (m_mainStatesMachine != null)
            {
                if(m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoUpdate();
                }  
            }
            MOtterApplication.GetInstance().SOUND.CheckIfAudioSourcesPlayingStoppedPlaying();
        }

        private void FixedUpdate()
        {
            if (m_mainStatesMachine != null)
            {
                if (m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoFixedUpdate();
                }
            }
        }

        private void LateUpdate()
        {
            if (m_mainStatesMachine != null)
            {
                if (m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoLateUpdate();
                }
            }
        }

        public void RegisterNewMainStateMachine(MainStatesMachine statesmachine)
        {
            if (m_mainStatesMachine != null)
            {
                StartCoroutine(m_mainStatesMachine.UnloadAsync());
            }
            m_mainStatesMachine = statesmachine;
            StartCoroutine(statesmachine.LoadAsync());
        }

        public T GetCurrentMainStateMachine<T>() where T : MainStatesMachine
        {
            if (m_mainStatesMachine != null)
            {
                return (T)m_mainStatesMachine;
            }
            else
            {
                return null;
            }

        }
    }
}