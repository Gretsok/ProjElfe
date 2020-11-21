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

        void Update()
        {
            if (m_mainStatesMachine != null)
            {
                m_mainStatesMachine.DoUpdate();
            }
            MOtterApplication.GetInstance().SOUND.CheckIfAudioSourcesPlayingStoppedPlaying();
        }

        public void RegisterNewMainStateMachine(MainStatesMachine statesmachine)
        {
            if (m_mainStatesMachine != null)
            {
                m_mainStatesMachine.ExitStateMachine();
            }
            m_mainStatesMachine = statesmachine;
            statesmachine.EnterStateMachine();
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