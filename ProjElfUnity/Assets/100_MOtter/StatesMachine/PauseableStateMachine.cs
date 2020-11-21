using UnityEngine;

namespace MOtter.StatesMachine
{
    public class PauseableStateMachine : MainStatesMachine
    {
        [SerializeField] private State m_pauseState = null;
        private bool isPaused = false;
        [SerializeField] private bool StopTimeInPause = true;
        public bool IsPaused => isPaused;

        public override void DoUpdate()
        {
            if (isPaused)
            {
                m_pauseState.UpdateState();
            }
            else
            {
                m_currentState.UpdateState();
            }

        }

        public virtual void Pause()
        {
            isPaused = true;
            if (StopTimeInPause)
                Time.timeScale = 0;
            m_pauseState.EnterState();
        }

        public virtual void Unpause()
        {
            isPaused = false;
            if (StopTimeInPause)
                Time.timeScale = 1;
            m_pauseState.ExitState();
        }
    }
}
