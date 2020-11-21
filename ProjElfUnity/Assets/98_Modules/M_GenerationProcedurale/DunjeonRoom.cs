using UnityEngine;


namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonRoom : MonoBehaviour
    {
        private bool m_isLeadingToEnd = true;
        private int m_roomsLeftUntilTheEnd = 0;
        [SerializeField, Tooltip("From where the room is created")]
        private Vector3 m_startPoint = Vector3.zero;

        public Vector3 GetRandomWalkablePoint()
        {
            return Vector3.zero;
        }
    }
}