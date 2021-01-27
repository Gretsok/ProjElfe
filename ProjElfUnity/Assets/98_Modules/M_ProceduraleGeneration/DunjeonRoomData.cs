using UnityEngine;



namespace ProjElf.ProceduraleGeneration
{
    [CreateAssetMenu(fileName = "DunjeonRoomData", menuName = "DunjeonGeneration/DunjeonRoomData")]
    public class DunjeonRoomData : ScriptableObject
    {
        [SerializeField, Tooltip("The prefab of the room")]
        private DunjeonRoom m_roomPrefab = null;
        [SerializeField, Tooltip("List of all ennemis prefab with their weight which impacts how often they will spawn")]
        private EnnemySpawnData[] m_ennemiesToSpawn = null;

        [Header("Range of numbers of ennemies to spawn")]
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_easyModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_mediumModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_hardModeNumberOfEnnemiesToSpawn = Vector2Int.zero;

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

        public int GetRandomNumberOfEnnemisToSpawn(EDunjeonDifficulty difficulty)
        {
            Random.InitState((new System.Random()).Next(0, 1000000));
            if(difficulty == EDunjeonDifficulty.easy)
            {
                return Random.Range(m_easyModeNumberOfEnnemiesToSpawn.x, m_easyModeNumberOfEnnemiesToSpawn.y);
            }
            else if(difficulty == EDunjeonDifficulty.medium)
            {
                return Random.Range(m_mediumModeNumberOfEnnemiesToSpawn.x, m_mediumModeNumberOfEnnemiesToSpawn.y);
            }
            else if(difficulty == EDunjeonDifficulty.hard)
            {
                return Random.Range(m_hardModeNumberOfEnnemiesToSpawn.x, m_hardModeNumberOfEnnemiesToSpawn.y);
            }
            Debug.LogError("No valid difficulty");
            return 0;
        }
    }
}