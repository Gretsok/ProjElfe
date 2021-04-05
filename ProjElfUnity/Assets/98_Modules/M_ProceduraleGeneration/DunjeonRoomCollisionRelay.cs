using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonRoomCollisionRelay : MonoBehaviour
    {
        [SerializeField]
        private DunjeonRoom m_dunjeonRoom = null;

        public DunjeonRoom DunjeonRoom => m_dunjeonRoom;

        public void ActivateSurroundingRooms()
        {
            m_dunjeonRoom.ActivateSurroundingRooms();
        }
    }
}