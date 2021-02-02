using MOtter;
using ProjElf.AI;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonRoom : MonoBehaviour
    {
        private DunjeonRoomData m_dunjeonRoomData = null;
        private List<GameObject> m_objectSpawnedInThisRoom = new List<GameObject>();
        private List<GenericAI> m_AISpawnedInThisRoom = new List<GenericAI>();
        public List<GenericAI> AISpawnedInThisRoom => m_AISpawnedInThisRoom;
        #region LifeCycle Attributes
        private bool m_isInit = false;
        internal bool IsInit => m_isInit;
        private bool m_roomSetUp = false;
        #endregion

        #region RoomPositions Attributes
        internal int PosX = 0;
        internal int PosY = 0;
        internal bool IsLeadingToTheEnd = true;
        internal int RoomsLeftUntilTheEnd = 0;
        internal ERoomOrientation RoomOrientation = ERoomOrientation.North;
        #endregion

        internal bool HasForwardGate = false;
        internal bool HasLeftGate = false;
        internal bool HasRightGate = false;

        private EDunjeonDifficulty m_dunjeonDifficulty = EDunjeonDifficulty.RescuerI;

        [SerializeField, Tooltip("Wiil affect random walkable point")]
        private float m_width = 10f;
        [SerializeField, Tooltip("Default LayerMask used to find random walkable point")]
        private LayerMask m_spawningLayerMask = 1111;

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


        #region CanGo CardinalDirections
        public bool CanGoNorth
        {
            get
            {
                switch(RoomOrientation)
                {
                    case ERoomOrientation.North:
                        return HasForwardGate;
                         
                    case ERoomOrientation.South:
                        return false;
                         
                    case ERoomOrientation.West:
                        return HasRightGate;
                         
                    case ERoomOrientation.East:
                        return HasLeftGate;
                         
                    default:
                        return false;
                         
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
                         
                    case ERoomOrientation.South:
                        return HasForwardGate;
                         
                    case ERoomOrientation.West:
                        return HasLeftGate;
                         
                    case ERoomOrientation.East:
                        return HasRightGate;
                         
                    default:
                        return false;
                         
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
                         
                    case ERoomOrientation.South:
                        return HasRightGate;
                         
                    case ERoomOrientation.West:
                        return HasForwardGate;
                         
                    case ERoomOrientation.East:
                        return false;
                         
                    default:
                        return false;
                         
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
                         
                    case ERoomOrientation.South:
                        return HasLeftGate;
                         
                    case ERoomOrientation.West:
                        return false;
                         
                    case ERoomOrientation.East:
                        return HasForwardGate;
                         
                    default:
                        return false;
                         
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
                         
                    case ERoomOrientation.South:
                        return BackwardGate;
                         
                    case ERoomOrientation.West:
                        return RightGate;
                         
                    case ERoomOrientation.East:
                        return LeftGate;
                         
                    default:
                        return null;
                         
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
                         
                    case ERoomOrientation.South:
                        return ForwardGate;
                         
                    case ERoomOrientation.West:
                        return LeftGate;
                         
                    case ERoomOrientation.East:
                        return RightGate;
                         
                    default:
                        return null;
                         
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
                         
                    case ERoomOrientation.South:
                        return RightGate;
                         
                    case ERoomOrientation.West:
                        return ForwardGate;
                         
                    case ERoomOrientation.East:
                        return BackwardGate;
                         
                    default:
                        return null;
                         
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
                         
                    case ERoomOrientation.South:
                        return LeftGate;
                         
                    case ERoomOrientation.West:
                        return BackwardGate;
                         
                    case ERoomOrientation.East:
                        return ForwardGate;
                         
                    default:
                        return null;
                         
                }
            }
        }

        #endregion

        /// <summary>
        /// Initialize room
        /// </summary>
        /// <param name="dunjeonRoomData"></param>
        internal void SetUpRoom(DunjeonRoomData dunjeonRoomData, EDunjeonDifficulty dunjeonDifficulty)
        {
            if (dunjeonRoomData == null) Debug.LogError("DUNJEON ROOM DATA NULL");
            m_dunjeonRoomData = dunjeonRoomData;
            HasForwardGate = m_dunjeonRoomData.ForwardGate;
            HasLeftGate = m_dunjeonRoomData.LeftGate;
            HasRightGate = m_dunjeonRoomData.RightGate;
            m_roomSetUp = true;
            m_dunjeonDifficulty = dunjeonDifficulty;
        }

        /// <summary>
        /// Activate room
        /// </summary>
        public void ActivateRoom()
        {
            //GetComponent<NavMeshSurface>().BuildNavMesh();
            if(!m_isInit && m_roomSetUp)
            {
                //Debug.Log("truc");
                int numberOfEnnemisToSpawn = m_dunjeonRoomData.GetRandomNumberOfEnnemisToSpawn(m_dunjeonDifficulty);
                m_isInit = true;

                for(int i = 0; i < numberOfEnnemisToSpawn; i++)
                {
                    GameObject ennemyToSpawnGO = m_dunjeonRoomData.GetRandomEnnemy();
                    m_objectSpawnedInThisRoom.Add(Instantiate(ennemyToSpawnGO, GetRandomWalkablePoint(), Quaternion.identity));
                    if(m_objectSpawnedInThisRoom[i].TryGetComponent<GenericAI>(out GenericAI newAI))
                    {
                        m_AISpawnedInThisRoom.Add(newAI);
                        newAI.Init(this);
                    }
                }
            }
        }

        public void ActivateSurroundingRooms()
        {
            MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>().DunjeonManager.ActivateRoomsAroundRoom(this);
        }


        public void UpdateAIInRoom()
        {
            for(int i = 0; i < m_AISpawnedInThisRoom.Count; i++)
            {
                m_AISpawnedInThisRoom[i].DoUpdate();
            }
        }

        public void FixedUpdateAIInRoom()
        {
            for (int i = 0; i < m_AISpawnedInThisRoom.Count; i++)
            {
                m_AISpawnedInThisRoom[i].DoFixedUpdate();
            }
        }

        public void LateUpdateAIInRoom()
        {
            for (int i = 0; i < m_AISpawnedInThisRoom.Count; i++)
            {
                m_AISpawnedInThisRoom[i].DoLateUpdate();
            }
        }

        /// <summary>
        /// Gets a point on the ground of the room. Mainly used to move AI and spawn objects
        /// </summary>
        /// <returns></returns>
        public Vector3 GetRandomWalkablePoint()
        {
            float x, z;
            Ray ray;
            RaycastHit hitInfos;
            NavMeshHit navHitInfos = new NavMeshHit();
            int MAX_ITERATION = 100;
            int nbIteration = 0;

            // We'll randomly raycast until we hit something or reach the MAX_ITERATION
            do
            {
                do
                {

                    System.Random rnd = new System.Random(Random.Range(0, 10000000));
                    Random.InitState(rnd.Next(0, 100000000));
                    x = Random.Range(-m_width / 2f, m_width / 2f);
                    Random.InitState(rnd.Next(0, 100000000));
                    z = Random.Range(-m_width / 2f, m_width / 2f);

                    Vector3 rayOrigin = transform.position
                        + x * transform.right
                        + z * transform.forward
                        + 20 * transform.up;
                    ray = new Ray(rayOrigin, Vector3.down);
                    nbIteration++;
                    //Debug.DrawLine(new Vector3(transform.position.x + x, transform.position.y + 20, transform.position.z + z), new Vector3(transform.position.x + x, transform.position.y + 20, transform.position.z + z) + Vector3.down * 40, Color.red, 120f);

                    Debug.DrawRay(ray.origin, ray.direction * 40f, Color.red, 200f);

                } while (!Physics.Raycast(ray, out hitInfos, 40f, m_spawningLayerMask) && nbIteration < MAX_ITERATION);
            } while (!NavMesh.SamplePosition(hitInfos.point, out navHitInfos, 1, 1) && nbIteration < MAX_ITERATION);

            //Debug.Log("Pos to spawn : x: " + (transform.position.x + x) + " z: " + (transform.position.z + z) + "   Pos room: x: " + transform.position.x + " z: " + transform.position.z);
            //Debug.Log("NavMesh:" + navHitInfos.position + " hitPoint: " + hitInfos.point + "navHitDist" + navHitInfos.distance);
            if (nbIteration >= MAX_ITERATION)
            {
                Debug.LogError($"MAX ITERATION HIT while trying to find a random walkable point on {gameObject.name}");
                Debug.Log($"{ray.ToString()}");

            }
            else
            {
                Debug.DrawLine(ray.origin, ray.origin + ray.direction * 40, Color.green, 120f);
            }

            return navHitInfos.position;
            
            
        }


        private void OnDestroy()
        {
            // When we destroy the room, we want to destroy every object that the rooms spawned (Should only happen when destroying the whole dunjeon)
            for(int i = 0; i < m_objectSpawnedInThisRoom.Count; i++)
            {
                Destroy(m_objectSpawnedInThisRoom[i].gameObject);
            }
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