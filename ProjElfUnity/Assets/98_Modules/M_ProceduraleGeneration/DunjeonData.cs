using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.ProceduraleGeneration
{
    [CreateAssetMenu(fileName = "DunjeonData", menuName = "DunjeonGeneration/DunjeonData")]
    public class DunjeonData : ScriptableObject
    {
        [SerializeField]
        private string m_dunjeonName = string.Empty;

        [SerializeField, Tooltip("Minimum and maximum of rooms making the way leading to the end")]
        private Vector2Int m_numberOfRoomsOnRightWay = Vector2Int.zero;
        [SerializeField, Tooltip("Minimum and maximum of rooms making a way not leading to the end")]
        private Vector2Int m_numberOfRoomsOnWrongWay = Vector2Int.zero;
        [SerializeField, Tooltip("Minimum and maximum of rooms between two intersections")]
        private Vector2Int m_intersectionSpawningRate = Vector2Int.zero;
        [SerializeField, Tooltip("Data of the final room")]
        private DunjeonRoomData m_finalRoomData = null;
        [SerializeField, Tooltip("Data of all rooms. It has to contain a room for each case (Mixing: canGoForward, canGoLeft, canGoRight)")]
        private List<DunjeonRoomData> m_rooms = new List<DunjeonRoomData>();

        [SerializeField, Tooltip("Dunjeon Difficulty")]
        private EDunjeonDifficulty m_dunjeonDifficulty = EDunjeonDifficulty.RescuerI;
        [SerializeField, Tooltip("Dunjeon Type")]
        private EDunjeonType m_dunjeonType = EDunjeonType.Castle;

        [SerializeField]
        private Sprite m_dunjeonIcon = null;

        [SerializeField]
        private SceneData.SceneData m_dunjeonSceneData = null;

        internal DunjeonRoomData FinalRoomData => m_finalRoomData;


        public string DunjeonName => m_dunjeonName;

        /// <summary>
        /// Get a random number of rooms making the way leading to the end
        /// </summary>
        /// <returns></returns>
        internal int GetRandomNumberOfRoomsOnRightWay()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_numberOfRoomsOnRightWay.x, m_numberOfRoomsOnRightWay.y);
        }
        /// <summary>
        /// Get a random number of rooms making a way not leading to the end
        /// </summary>
        /// <returns></returns>
        internal int GetRandomNumberOfRoomsOnWrongWay()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_numberOfRoomsOnWrongWay.x, m_numberOfRoomsOnWrongWay.y);
        }

        /// <summary>
        /// Get a random number of rooms before the next intersection
        /// </summary>
        /// <returns></returns>
        internal int GetIntersectionSpawningRate()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_intersectionSpawningRate.x, m_intersectionSpawningRate.y);
        }

        /// <summary>
        /// Get a random room depending on if it can go forward, left or right
        /// </summary>
        /// <param name="hasForwardGate"></param>
        /// <param name="hasLeftGate"></param>
        /// <param name="hasRightGate"></param>
        /// <returns></returns>
        public DunjeonRoomData GetRandomRoom(bool hasForwardGate, bool hasLeftGate, bool hasRightGate)
        {
            List<DunjeonRoomData> tempList = m_rooms.FindAll(x => x.ForwardGate == hasForwardGate && x.LeftGate == hasLeftGate && x.RightGate == hasRightGate);
            Random.InitState((new System.Random()).Next(0, 1000000));
            int randomIndex = Random.Range(0, tempList.Count);
            //Debug.Log("random room index: "+randomIndex + " tempList count : " + tempList.Count);
            //Debug.Log("forw: " + hasForwardGate + " left: " + hasLeftGate + " right: " + hasRightGate);
            return tempList[randomIndex];
        }

        public EDunjeonDifficulty DunjeonDifficulty => m_dunjeonDifficulty;
        public EDunjeonType DunjeonType => m_dunjeonType;
        public Sprite DunjeonIcon => m_dunjeonIcon;
        public SceneData.SceneData DunjeonSceneData => m_dunjeonSceneData;
    }
}