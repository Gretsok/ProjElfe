﻿using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.ProceduraleGeneration
{
    [CreateAssetMenu(fileName = "DunjeonData", menuName = "DunjeonGeneration/DunjeonData")]
    public class DunjeonData : ScriptableObject
    {
        
        [SerializeField]
        private Vector2Int m_numberOfRoomsOnRightWay = Vector2Int.zero;
        [SerializeField]
        private Vector2Int m_numberOfRoomsOnWrongWay = Vector2Int.zero;
        [SerializeField]
        private Vector2Int m_intersectionSpawningRate = Vector2Int.zero;
        [SerializeField]
        private DunjeonRoomData m_finalRoomData = null;
        [SerializeField]
        private List<DunjeonRoomData> m_rooms = new List<DunjeonRoomData>();

        internal DunjeonRoomData FinalRoomData => m_finalRoomData;

        internal int GetRandomNumberOfRoomsOnRightWay()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_numberOfRoomsOnRightWay.x, m_numberOfRoomsOnRightWay.y);
        }
        internal int GetRandomNumberOfRoomsOnWrongWay()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_numberOfRoomsOnWrongWay.x, m_numberOfRoomsOnWrongWay.y);
        }

        internal int GetIntersectionSpawningRate()
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            return Random.Range(m_intersectionSpawningRate.x, m_intersectionSpawningRate.y);
        }

        public DunjeonRoomData GetRandomRoom(bool hasForwardGate, bool hasLeftGate, bool hasRightGate)
        {
            List<DunjeonRoomData> tempList = m_rooms.FindAll(x => x.ForwardGate == hasForwardGate && x.LeftGate == hasLeftGate && x.RightGate == hasRightGate);
            Random.InitState((new System.Random()).Next(0, 1000000));
            int randomIndex = Random.Range(0, tempList.Count);
            //Debug.Log("random room index: "+randomIndex + " tempList count : " + tempList.Count);
            Debug.Log("forw: " + hasForwardGate + " left: " + hasLeftGate + " right: " + hasRightGate);
            return tempList[randomIndex];
        }
    }
}