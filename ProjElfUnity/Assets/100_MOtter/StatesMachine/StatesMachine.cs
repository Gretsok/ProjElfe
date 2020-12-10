using System;
using System.Collections;
using UnityEngine;


namespace MOtter.StatesMachine
{
    public class StatesMachine : MonoBehaviour
    {
        [SerializeField] protected State m_defaultState = null;
        protected State m_currentState = null;
        private bool m_isLoaded = false;
        private bool m_isUnloaded = false;

        public bool IsLoaded => m_isLoaded;
        public bool IsUnloaded => m_isUnloaded;

        protected virtual void EnterStateMachine()
        {
            SwitchToState(m_defaultState);
        }

        public virtual void DoUpdate()
        {
            m_currentState?.UpdateState();
        }

        public virtual void DoFixedUpdate()
        {
            m_currentState?.FixedUpdateState();
        }

        public virtual void DoLateUpdate()
        {
            m_currentState?.LateUpdateState();
        }

        protected virtual void ExitStateMachine()
        {

        }

        public void SwitchToState(State state)
        {
            if (m_currentState != null)
            {
                state.PreviousState = m_currentState;
                m_currentState?.ExitState();
            }
            m_currentState = state;
            m_currentState?.EnterState();
        }

        public void SwitchToNextState()
        {
            SwitchToState(m_currentState.NextState);
        }

        public virtual IEnumerator LoadAsync()
        {
            yield return null;
            m_isLoaded = true;
            EnterStateMachine();
        }

        public virtual IEnumerator UnloadAsync(Action onUnloadEnded)
        {

            yield return null;
            m_isUnloaded = true;
            ExitStateMachine();
            if(onUnloadEnded != null) onUnloadEnded();
        }

        private void OnDestroy()
        {
            ExitStateMachine();
        }
    }
}