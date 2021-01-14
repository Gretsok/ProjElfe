using System;
using UnityEngine;

namespace MOtter.StatesMachine
{
    public class PauseableStateMachine : MainStatesMachine
    {
        [SerializeField] private StatesMachine m_pauseStatesMachine = null;
        private bool isPaused = false;
        [SerializeField] private bool StopTimeInPause = true;
        public bool IsPaused => isPaused;

        public Action OnPause = null;
        public Action OnUnpause = null;

        public override void DoUpdate()
        {
            if (isPaused)
            {
                m_pauseStatesMachine?.DoUpdate();
            }
            else
            {
                m_currentState?.UpdateState();
            }

        }
        public override void DoFixedUpdate()
        {
            if (isPaused)
            {
                m_pauseStatesMachine?.DoFixedUpdate();
            }
            else
            {
                m_currentState?.FixedUpdateState();
            }

        }

        public override void DoLateUpdate()
        {
            if (isPaused)
            {
                m_pauseStatesMachine?.DoLateUpdate();
            }
            else
            {
                m_currentState?.LateUpdateState();
            }

        }

        public virtual void Pause()
        {
            isPaused = true;
            if (StopTimeInPause)
                Time.timeScale = 0;
            OnPause?.Invoke();
            m_pauseStatesMachine.EnterStateMachine();
        }

        public virtual void Unpause()
        {
            isPaused = false;
            if (StopTimeInPause)
                Time.timeScale = 1;
            m_pauseStatesMachine.ExitStateMachine();
            OnUnpause?.Invoke();
        }
    }
}
