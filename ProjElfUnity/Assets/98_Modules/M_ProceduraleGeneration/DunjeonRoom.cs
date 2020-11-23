using UnityEngine;


namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonRoom : MonoBehaviour
    {
        private DunjeonRoomData m_dunjeonRoomData = null;
        private bool m_isLeadingToEnd = true;
        private int m_roomsLeftUntilTheEnd = 0;

        internal ERoomOrientation RoomOrientation = ERoomOrientation.North;

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

        internal int PosX = 0;
        internal int PosY = 0;

        #region CanGo CardinalDirections
        public bool CanGoNorth
        {
            get
            {
                switch(RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return HasForwardGate;
                        break;
                    case ERoomOrientation.South:
                        return false;
                        break;
                    case ERoomOrientation.West:
                        return HasRightGate;
                        break;
                    case ERoomOrientation.East:
                        return HasLeftGate;
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }

        public bool CanGoSouth
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return false;
                        break;
                    case ERoomOrientation.South:
                        return HasForwardGate;
                        break;
                    case ERoomOrientation.West:
                        return HasLeftGate;
                        break;
                    case ERoomOrientation.East:
                        return HasRightGate;
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }

        public bool CanGoWest
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return HasLeftGate;
                        break;
                    case ERoomOrientation.South:
                        return HasRightGate;
                        break;
                    case ERoomOrientation.West:
                        return HasForwardGate;
                        break;
                    case ERoomOrientation.East:
                        return false;
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }

        public bool CanGoEast
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return HasRightGate;
                        break;
                    case ERoomOrientation.South:
                        return HasLeftGate;
                        break;
                    case ERoomOrientation.West:
                        return false;
                        break;
                    case ERoomOrientation.East:
                        return HasForwardGate;
                        break;
                    default:
                        return false;
                        break;
                }
            }
        }

        #endregion
        #region Gates CardinalDirections
        public Transform NorthGate
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return ForwardGate;
                        break;
                    case ERoomOrientation.South:
                        return BackwardGate;
                        break;
                    case ERoomOrientation.West:
                        return RightGate;
                        break;
                    case ERoomOrientation.East:
                        return LeftGate;
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        public Transform SouthGate
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return BackwardGate;
                        break;
                    case ERoomOrientation.South:
                        return ForwardGate;
                        break;
                    case ERoomOrientation.West:
                        return LeftGate;
                        break;
                    case ERoomOrientation.East:
                        return RightGate;
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        public Transform WestGate
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return LeftGate;
                        break;
                    case ERoomOrientation.South:
                        return RightGate;
                        break;
                    case ERoomOrientation.West:
                        return ForwardGate;
                        break;
                    case ERoomOrientation.East:
                        return BackwardGate;
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        public Transform EastGate
        {
            get
            {
                switch (RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return RightGate;
                        break;
                    case ERoomOrientation.South:
                        return LeftGate;
                        break;
                    case ERoomOrientation.West:
                        return BackwardGate;
                        break;
                    case ERoomOrientation.East:
                        return ForwardGate;
                        break;
                    default:
                        return null;
                        break;
                }
            }
        }

        #endregion

        internal void SetUpRoom(DunjeonRoomData dunjeonRoomData)
        {
            m_dunjeonRoomData = dunjeonRoomData;
            HasForwardGate = m_dunjeonRoomData.ForwardGate;
            HasLeftGate = m_dunjeonRoomData.LeftGate;
            HasRightGate = m_dunjeonRoomData.RightGate;
        }

        public Vector3 GetRandomWalkablePoint()
        {
            return Vector3.zero;
        }
    }

    public enum ERoomOrientation
    {
        North,
        South,
        West,
        East
    }
}