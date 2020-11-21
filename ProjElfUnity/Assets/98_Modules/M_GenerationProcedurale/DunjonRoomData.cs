﻿using UnityEngine;



namespace ProjElf.ProceduraleGeneration
{
    public class DunjonRoomData : ScriptableObject
    {
        [SerializeField, Tooltip("The prefab of the room")]
        private DunjeonRoom m_roomPrefab = null;
        [SerializeField, Tooltip("List of all ennemis prefab with their weight which impacts how often they will spawn")]
        private EnnemySpawnData[] m_ennemiesToSpawn = null;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_numberOfEnnemiesToSpawn = Vector2Int.zero;

        [SerializeField]
        private bool m_forwardGate = false;
        [SerializeField]
        private bool m_leftGate = false;
        [SerializeField]
        private bool m_rightGate = false;

        public DunjeonRoom DunjeonRoom => m_roomPrefab;
        public bool ForwardGate => m_forwardGate;
        public bool LeftGate => m_leftGate;
        public bool RightGate => m_rightGate;


        public GameObject GetRandomEnnemy()
        {
            return m_ennemiesToSpawn[0].EnnemyPrefab;
        }
    }
}