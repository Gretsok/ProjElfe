using UnityEngine;


namespace MOtter.StatesMachine
{
    public class StatesMachine : MonoBehaviour
    {
        [SerializeField] protected State m_defaultState = null;
        protected State m_currentState = null;

        public virtual void EnterStateMachine()
        {
            SwitchToState(m_defaultState);
        }

        public virtual void DoUpdate()
        {
            m_currentState?.UpdateState();
        }

        public virtual void ExitStateMachine()
        {

        }

        public void SwitchToState(State state)
        {
            if (m_currentState != null)
            {
                state.PreviousState = m_currentState;
                m_currentState.ExitState();
            }
            m_currentState = state;
            m_currentState.EnterState();
        }

        public void SwitchToNextState()
        {
            SwitchToState(m_currentState.NextState);
        }

        private void OnDestroy()
        {
            ExitStateMachine();
        }
    }
}