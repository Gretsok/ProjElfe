using System.Collections.Generic;
using UnityEngine;



namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonManager : MonoBehaviour
    {
        [SerializeField]
        private DunjeonData m_currentDunjeonData = null;
        private int m_numberOfRoomsOnRightWay = 0;
        private List<List<DunjeonRoom>> m_instantiatedRooms = new List<List<DunjeonRoom>>();
        [SerializeField]
        private Transform m_firstGate = null;

        private void Awake()
        {
            m_numberOfRoomsOnRightWay = m_currentDunjeonData.GetRandomNumberOfRoomsOnRightWay();
            GenerateDunjeon();
        }

        private void GenerateDunjeon()
        {
            GenerateNewRoom(m_firstGate, 0, 0);
        }

        private void GenerateNewRoom(Transform doorConnection, int posX, int posY)
        {
            DunjeonRoomData roomData = m_currentDunjeonData.GetRandomRoom(true, true, true);
            DunjeonRoom room = Instantiate(roomData.DunjeonRoom);
            room.transform.rotation = doorConnection.rotation;
            room.transform.position += (doorConnection.position - room.BackwardGate.position);
            RegisterRoomAtPosition(room, posX, posY);
        }

        private void RegisterRoomAtPosition(DunjeonRoom room, int posX, int posY)
        {
            if(posX >= m_instantiatedRooms.Count)
            {
                for(int i = m_instantiatedRooms.Count - 1; i < posX; i++)
                {
                    m_instantiatedRooms.Add(new List<DunjeonRoom>());
                }
            }
            if (posY >= m_instantiatedRooms[posX].Count)
            {
                for (int i = m_instantiatedRooms[posX].Count - 1; i < posY; i++)
                {
                    m_instantiatedRooms[posX].Add(null);
                }
            }
            if(m_instantiatedRooms[posX][posY] != null)
            {
                Debug.LogError($"A room has already been generated at positions x:{posX} y:{posY}");
            }
            else
            {
                m_instantiatedRooms[posX][posY] = room;
            }
        }
    }
}