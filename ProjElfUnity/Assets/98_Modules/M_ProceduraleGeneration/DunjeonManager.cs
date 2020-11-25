using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonManager : MonoBehaviour
    {
        [SerializeField]
        private DunjeonData m_currentDunjeonData = null;
        private int m_numberOfRoomsOnRightWay = 0;
        private List<List<DunjeonRoom>> m_instantiatedRoomsGrid = new List<List<DunjeonRoom>>();
        private List<DunjeonRoom> m_instantiatedRooms = new List<DunjeonRoom>();
        private int m_generatingRoomsRoomIndex = 0;
        [SerializeField]
        private DunjeonRoom m_firstRoom = null;
        [SerializeField]
        private Vector2Int m_initPositions = Vector2Int.zero;


        private void Awake()
        {
            m_numberOfRoomsOnRightWay = m_currentDunjeonData.GetRandomNumberOfRoomsOnRightWay();
            GenerateDunjeon();
        }

        private void Update()
        {
            if(m_generatingRoomsRoomIndex < m_instantiatedRooms.Count)
            {
                //Debug.Log("Trying to generate surrounding rooms of room x:" + m_instantiatedRooms[m_generatingRoomsRoomIndex].PosX + " y:" + m_instantiatedRooms[m_generatingRoomsRoomIndex].PosY);
                GenerateSurroundingRooms(m_instantiatedRooms[m_generatingRoomsRoomIndex]);
                m_generatingRoomsRoomIndex++;
            }
        }

        private void GenerateDunjeon()
        {
            RegisterRoomAtPosition(m_firstRoom, m_initPositions.x, m_initPositions.y);
            GenerateNewRoom(m_firstRoom.ForwardGate, m_initPositions.x, m_initPositions.y + 1, ERoomOrientation.North, 20);
        }

        /// <summary>
        /// Generate new Room
        /// </summary>
        /// <param name="doorConnection">Transform that will orientate and position new room</param>
        /// <param name="posX">x index of new room</param>
        /// <param name="posY">y index of new room</param>
        /// <param name="roomOrientation">room orientation according to first gate</param>
        /// <param name="onRightWay">Whether the room to be spawn is on the way to the end or not</param>
        private void GenerateNewRoom(Transform doorConnection, int posX, int posY, ERoomOrientation roomOrientation, int roomsLeft, bool onRightWay = true)
        {
            if (roomsLeft > 0 && IsLocationFree(posX, posY))
            {
                EDirectionState canGoLeft = EDirectionState.False;
                EDirectionState canGoRight = EDirectionState.False;
                EDirectionState canGoForward = EDirectionState.False;
                EDirectionState canGoBackward = EDirectionState.False; // Should always be set to false when sent to CheckDirectionToGo, if not there is a problem :(
                //Debug.Log("Checking posX:" + posX + " posY:" + posY);
                switch (roomOrientation)
                {
                    case ERoomOrientation.North:
                        CheckDirectionToGo(out canGoForward, out canGoBackward, out canGoRight, out canGoLeft, posX, posY);
                        break;
                    case ERoomOrientation.South:
                        CheckDirectionToGo(out canGoBackward, out canGoForward, out canGoLeft, out canGoRight, posX, posY);
                        break;
                    case ERoomOrientation.West:
                        CheckDirectionToGo(out canGoRight, out canGoLeft, out canGoBackward, out canGoForward, posX, posY);
                        break;
                    case ERoomOrientation.East:
                        CheckDirectionToGo(out canGoLeft, out canGoRight, out canGoForward, out canGoBackward, posX, posY);
                        break;
                }
                //Debug.Log("Checking posX:" + posX + " posY:" + posY + " canGoLeft: " + canGoLeft + " canGoRight:" + canGoRight + " canGoForward:" + canGoForward + " orientation:" + roomOrientation);
                
                List<DunjeonRoomData> possibleRooms = GetPossibleRooms(canGoLeft, canGoRight, canGoForward, onRightWay && roomsLeft%5 == 0 ? false : true, roomsLeft < 2 ? true : false);


                Random.InitState((new System.Random()).Next(0, 1000000));
                DunjeonRoomData roomData = possibleRooms[Random.Range(0, possibleRooms.Count)];


                DunjeonRoom room = Instantiate(roomData.DunjeonRoom);
                room.transform.rotation = doorConnection.rotation;
                room.transform.position += (doorConnection.position - room.BackwardGate.position);
                room.RoomOrientation = roomOrientation;
                room.SetUpRoom(roomData);
                room.PosX = posX;
                room.PosY = posY;
                room.RoomsLeftUntilTheEnd = --roomsLeft;
                room.IsLeadingToTheEnd = onRightWay;
                RegisterRoomAtPosition(room, posX, posY);
            }
        }

        /// <summary>
        /// Generate all rooms next to doors of the current room
        /// </summary>
        /// <param name="room"></param>
        private void GenerateSurroundingRooms(DunjeonRoom room)
        {
            if (room.IsLeadingToTheEnd)
            {
                int roomToSpawn = 0;
                if (room.CanGoNorth)
                {
                    roomToSpawn++;
                }
                if (room.CanGoSouth)
                {
                    roomToSpawn++;
                }
                if (room.CanGoWest)
                {
                    roomToSpawn++;
                }
                if (room.CanGoEast)
                {
                    roomToSpawn++;
                }

                Random.InitState((new System.Random()).Next(0, 1000000));
                int roomOnRightWayIndex = Random.Range(0, roomToSpawn);
                roomToSpawn = 0;
                bool roomOnGoodWayChosen = false;

                if (room.CanGoNorth)
                {
                    if (!roomOnGoodWayChosen && roomToSpawn <= roomOnRightWayIndex)
                    {
                        GenerateNewRoom(room.NorthGate, room.PosX, room.PosY + 1, ERoomOrientation.North, room.RoomsLeftUntilTheEnd);
                        roomOnGoodWayChosen = true;
                    }
                    else
                    {
                        GenerateNewRoom(room.NorthGate, room.PosX, room.PosY + 1, ERoomOrientation.North, m_currentDunjeonData.GetRandomNumberOfRoomsOnWrongWay(), false);
                    }
                }
                if (room.CanGoSouth)
                {
                    if (!roomOnGoodWayChosen && roomToSpawn <= roomOnRightWayIndex)
                    {
                        GenerateNewRoom(room.SouthGate, room.PosX, room.PosY - 1, ERoomOrientation.South, room.RoomsLeftUntilTheEnd);
                        roomOnGoodWayChosen = true;
                    }
                    else
                    {
                        GenerateNewRoom(room.SouthGate, room.PosX, room.PosY - 1, ERoomOrientation.South, m_currentDunjeonData.GetRandomNumberOfRoomsOnWrongWay(), false);
                    }
                }
                if (room.CanGoWest)
                {
                    if (!roomOnGoodWayChosen && roomToSpawn <= roomOnRightWayIndex)
                    {
                        GenerateNewRoom(room.WestGate, room.PosX - 1, room.PosY, ERoomOrientation.West, room.RoomsLeftUntilTheEnd);
                        roomOnGoodWayChosen = true;
                    }
                    else
                    {
                        GenerateNewRoom(room.WestGate, room.PosX - 1, room.PosY, ERoomOrientation.West, m_currentDunjeonData.GetRandomNumberOfRoomsOnWrongWay(), false);

                    }
                }
                if (room.CanGoEast)
                {
                    if (!roomOnGoodWayChosen && roomToSpawn <= roomOnRightWayIndex)
                    {
                        GenerateNewRoom(room.EastGate, room.PosX + 1, room.PosY, ERoomOrientation.East, room.RoomsLeftUntilTheEnd);
                        roomOnGoodWayChosen = true;
                    }
                    else
                    {
                        GenerateNewRoom(room.EastGate, room.PosX + 1, room.PosY, ERoomOrientation.East, m_currentDunjeonData.GetRandomNumberOfRoomsOnWrongWay(), false);
                    }
                }
            }
            else
            {
                if (room.CanGoNorth)
                {
                    GenerateNewRoom(room.NorthGate, room.PosX, room.PosY + 1, ERoomOrientation.North, room.RoomsLeftUntilTheEnd, false);
                }
                if (room.CanGoSouth)
                {
                    GenerateNewRoom(room.SouthGate, room.PosX, room.PosY - 1, ERoomOrientation.South, room.RoomsLeftUntilTheEnd, false);
                }
                if (room.CanGoWest)
                {
                    GenerateNewRoom(room.WestGate, room.PosX - 1, room.PosY, ERoomOrientation.West, room.RoomsLeftUntilTheEnd, false);
                }
                if (room.CanGoEast)
                {
                    GenerateNewRoom(room.EastGate, room.PosX + 1, room.PosY, ERoomOrientation.East, room.RoomsLeftUntilTheEnd, false);
                }
            }
        }

        /// <summary>
        /// Get every rooms that can be spawned according to directions states
        /// </summary>
        /// <param name="canGoLeft"></param>
        /// <param name="canGoRight"></param>
        /// <param name="canGoForward"></param>
        /// <param name="corridorOnly">Only use corridors or use every rooms</param>
        /// <param name="impasse">Use impasse rooms or do not</param>
        /// <returns></returns>
        private List<DunjeonRoomData> GetPossibleRooms(EDirectionState canGoLeft, EDirectionState canGoRight, EDirectionState canGoForward, bool corridorOnly = false, bool impasse = false)
        {
            List<DunjeonRoomData> possibleRooms = new List<DunjeonRoomData>(); // Add uniquement si != null
            DunjeonRoomData roomDataTemp = null;

            /*Example
             roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
             */

            if(canGoLeft == EDirectionState.True)
            {
                if (canGoRight == EDirectionState.True)
                {
                    // LEFT RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // LEFT RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // LEFT RIGHT
                    else
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                }
                else if (canGoRight == EDirectionState.Maybe)
                {
                    // LEFT ?RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // LEFT ?RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {      
                        
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // LEFT ?RIGHT
                    else
                    {                    
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                }
                else
                {
                    // LEFT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);

                    }
                    // LEFT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {                
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // LEFT
                    else
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                }
            }
            else if( canGoLeft == EDirectionState.Maybe)
            {
                if (canGoRight == EDirectionState.True)
                {
                    // ?LEFT RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // ?LEFT RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // ?LEFT RIGHT
                    else
                    {              
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                }
                else if (canGoRight == EDirectionState.Maybe)
                {
                    // ?LEFT ?RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {                        
                        if(!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        
                    }
                    // ?LEFT ?RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {                           
                            if (!corridorOnly)
                            {
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            }
                            else
                            {
                                // generate random number to favorize forward corridor
                                Random.InitState((new System.Random().Next(0, 11651615)));
                                int randValue = Random.Range(0, 10);
                                if(randValue < 1)
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                else if(randValue < 2)
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                else
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                            }
                        }
                    }
                    // ?LEFT ?RIGHT
                    else
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            if (!corridorOnly)
                            {
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            }
                            else
                            {
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            }
                        }
                    }
                }
                else
                {
                    // ?LEFT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // ?LEFT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            
                            if (!corridorOnly)
                            {
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, true, false);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            }
                            else
                            {
                                Random.InitState((new System.Random()).Next(0, 15164462));
                                int randValue = Random.Range(0, 10);
                                if(randValue >= 8)
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                else
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                
                            }
                        }
                    }
                    // ?LEFT
                    else
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, true, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                }
            }
            else
            {
                if (canGoRight == EDirectionState.True)
                {
                    // RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    { 
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // RIGHT
                    else
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                }
                else if (canGoRight == EDirectionState.Maybe)
                {
                    // ?RIGHT FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        if (!corridorOnly)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // ?RIGHT ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            
                            if (!corridorOnly)
                            {
                                roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, true);
                                if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                            }
                            else
                            {
                                Random.InitState((new System.Random()).Next(0, 15164462));
                                int randValue = Random.Range(0, 10);
                                if(randValue >= 8)
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                else
                                {
                                    roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                                    if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                                }
                                
                            }
                        }
                    }
                    // ?RIGHT
                    else
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, true);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                }
                else
                {
                    // FORWARD
                    if (canGoForward == EDirectionState.True)
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                    // ?FORWARD
                    else if (canGoForward == EDirectionState.Maybe)
                    {
                        if (impasse)
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                        else
                        {
                            roomDataTemp = m_currentDunjeonData.GetRandomRoom(true, false, false);
                            if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                        }
                    }
                    // Impasse
                    else
                    {
                        roomDataTemp = m_currentDunjeonData.GetRandomRoom(false, false, false);
                        if (roomDataTemp != null) possibleRooms.Add(roomDataTemp);
                    }
                }
            }
            
            return possibleRooms;
        }

        /// <summary>
        /// Checking where a room at [posX, posY] can lead in global dunjeon orientation
        /// </summary>
        /// <param name="canGoNorth"></param>
        /// <param name="canGoSouth"></param>
        /// <param name="canGoEast"></param>
        /// <param name="canGoWest"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        private void CheckDirectionToGo(out EDirectionState canGoNorth, out EDirectionState canGoSouth, out EDirectionState canGoEast, out EDirectionState canGoWest, int posX, int posY)
        {
            canGoNorth = EDirectionState.False;
            canGoSouth = EDirectionState.False;
            canGoEast = EDirectionState.False;
            canGoWest = EDirectionState.False;


            // Checking North
            bool roomFurther = false;
            if(m_instantiatedRoomsGrid.Count >= (posX + 1))
            {
                if(m_instantiatedRoomsGrid[posX].Count >= (posY + 2))
                {
                    if (m_instantiatedRoomsGrid[posX][posY + 1] != null)
                    {
                        roomFurther = true;
                    }
                }
            }
            
            if (roomFurther)
            {
                if(m_instantiatedRoomsGrid[posX][posY + 1].CanGoSouth)
                {
                    canGoNorth = EDirectionState.True;
                }
                else
                {
                    canGoNorth = EDirectionState.False;
                }
                            }
            else
            {
                canGoNorth = EDirectionState.Maybe;
            }

            // Checking South
            if(posY > 0)
            {
                roomFurther = false;
                if(m_instantiatedRoomsGrid.Count >= posX + 1)
                {
                    if(m_instantiatedRoomsGrid[posX].Count >= posY)
                    {
                        if (m_instantiatedRoomsGrid[posX][posY - 1] != null)
                        {
                            roomFurther = true;
                        }
                    }
                }
                if (roomFurther)
                {
                    if(m_instantiatedRoomsGrid[posX][posY - 1].CanGoNorth)
                    {
                        canGoSouth = EDirectionState.True;
                    }
                    else
                    {
                        canGoSouth = EDirectionState.False;
                    }
                    
                }
                else
                {
                    canGoSouth = EDirectionState.Maybe;
                }
            }
            else
            {
                canGoSouth = EDirectionState.False;
            }


            // Checking East
            roomFurther = false;
            if (m_instantiatedRoomsGrid.Count >= posX + 2)
            {
                if (m_instantiatedRoomsGrid[posX + 1].Count >= posY + 1)
                {
                    if (m_instantiatedRoomsGrid[posX + 1][posY] != null)
                    {
                        roomFurther = true;
                    }
                }                 
            }
            if (roomFurther)
            {
                if(m_instantiatedRoomsGrid[posX + 1][posY].CanGoWest)
                {
                    canGoEast = EDirectionState.True;
                }
                else
                {
                    canGoEast = EDirectionState.False;
                }
            }
            else
            {
                canGoEast = EDirectionState.Maybe;
            }

            // Checking West
            if (posX > 0)
            {
                roomFurther = false;
                if (m_instantiatedRooms.Count >= posX)
                {
                    if (m_instantiatedRoomsGrid[posX - 1].Count >= posY + 1)
                    {
                        if (m_instantiatedRoomsGrid[posX - 1][posY] != null)
                        {
                            roomFurther = true;
                            Debug.Log("Room at west detected");
                        }
                        Debug.Log("B");
                    }
                }
                if (roomFurther)
                {
                    if(m_instantiatedRoomsGrid[posX - 1][posY].CanGoEast)
                    {
                        canGoWest = EDirectionState.True;
                        Debug.Log("this room can go east");
                    }
                    {
                        canGoWest = EDirectionState.False;
                    }
                }
                else
                {
                    Debug.Log("maybe could go east");
                    canGoWest = EDirectionState.Maybe;
                }
            }
            else
            {
                canGoWest = EDirectionState.False;
            }
        }

        /// <summary>
        /// Add a room to the known rooms at position [posX, posY].
        /// </summary>
        /// <param name="room"></param>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        private void RegisterRoomAtPosition(DunjeonRoom room, int posX, int posY)
        {
            if(posX >= m_instantiatedRoomsGrid.Count)
            {
                for(int i = m_instantiatedRoomsGrid.Count - 1; i < posX; i++)
                {
                    m_instantiatedRoomsGrid.Add(new List<DunjeonRoom>());
                }
            }
            if (posY >= m_instantiatedRoomsGrid[posX].Count)
            {
                for (int i = m_instantiatedRoomsGrid[posX].Count - 1; i < posY; i++)
                {
                    m_instantiatedRoomsGrid[posX].Add(null);
                }
            }
            if(m_instantiatedRoomsGrid[posX][posY] != null)
            {
                Debug.LogError($"A room has already been generated at positions x:{posX} y:{posY}");
            }
            else
            {
                m_instantiatedRoomsGrid[posX][posY] = room;
                m_instantiatedRooms.Add(room);
                //Debug.Log("Adding new room, now : " + m_instantiatedRooms.Count);
            }
        }

        /// <summary>
        /// Check if we can place a room at [posX, posY].
        /// </summary>
        /// <param name="posX"></param>
        /// <param name="posY"></param>
        /// <returns></returns>
        private bool IsLocationFree(int posX, int posY)
        {
            if(m_instantiatedRoomsGrid.Count > posX)
            {
                if(m_instantiatedRoomsGrid[posX].Count > posY)
                {
                    if(m_instantiatedRoomsGrid[posX][posY] != null)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

    public enum EDirectionState
    {
        True,
        False,
        Maybe
    }
}