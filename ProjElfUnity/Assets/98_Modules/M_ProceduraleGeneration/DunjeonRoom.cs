using UnityEngine;


namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonRoom : MonoBehaviour
    {
        private bool m_isLeadingToEnd = true;
        private int m_roomsLeftUntilTheEnd = 0;

        internal bool HasForwardGate = false;
        internal bool HasLeftGate = false;
        internal bool HasRightGate = false;

        [SerializeField]
        private Transform m_forwardGate = null;
        [SerializeField]
        private Transform m_leftGate = null;
        [SerializeField]
        private Transform m_rightGate = null;
        [SerializeField]
        private Transform m_backwardGate = null;

        public Transform ForwardGate => m_forwardGate;
        public Transform LeftGate => m_leftGate;
        public Transform RightGate => m_rightGate;
        public Transform BackwardGate => m_backwardGate;

        public Vector3 GetRandomWalkablePoint()
        {
            return Vector3.zero;
        }
    }
}