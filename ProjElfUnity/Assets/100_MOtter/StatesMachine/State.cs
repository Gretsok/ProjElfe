using UnityEngine;

namespace MOtter.StatesMachine
{
    public class State : MonoBehaviour
    {
        [SerializeField] private State m_nextState = null;

        public State NextState => m_nextState;
        public State PreviousState { get; set; }

        public virtual void EnterState()
        {
            Debug.Log("EnterState : " + gameObject.name);
        }

        public virtual void UpdateState()
        {

        }

        public virtual void ExitState()
        {
            Debug.Log("ExitState : " + gameObject.name);
        }
    }
}