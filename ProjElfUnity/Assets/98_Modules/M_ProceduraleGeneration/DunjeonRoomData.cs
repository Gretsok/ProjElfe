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
        private Vector2Int m_rescuerIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_rescuerIIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_rescuerIIIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_lifeSaverIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_lifeSaverIIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_lifeSaverIIIModeNumberOfEnnemiesToSpawn = Vector2Int.zero;
        [SerializeField, Tooltip("Range of the number of ennemies to spawn")]
        private Vector2Int m_absoluteMasterGuardianModeNumberOfEnnemiesToSpawn = Vector2Int.zero;

        [Space(50)]
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
            if(difficulty == EDunjeonDifficulty.RescuerI)
            {
                return Random.Range(m_rescuerIModeNumberOfEnnemiesToSpawn.x, m_rescuerIModeNumberOfEnnemiesToSpawn.y);
            }
            else if(difficulty == EDunjeonDifficulty.RescuerII)
            {
                return Random.Range(m_rescuerIIModeNumberOfEnnemiesToSpawn.x, m_rescuerIIModeNumberOfEnnemiesToSpawn.y);
            }
            else if (difficulty == EDunjeonDifficulty.RescuerIII)
            {
                return Random.Range(m_rescuerIIIModeNumberOfEnnemiesToSpawn.x, m_rescuerIIIModeNumberOfEnnemiesToSpawn.y);
            }
            else if (difficulty == EDunjeonDifficulty.LifeSaverI)
            {
                return Random.Range(m_lifeSaverIModeNumberOfEnnemiesToSpawn.x, m_lifeSaverIModeNumberOfEnnemiesToSpawn.y);
            }
            else if (difficulty == EDunjeonDifficulty.LifeSaverII)
            {
                return Random.Range(m_lifeSaverIIModeNumberOfEnnemiesToSpawn.x, m_lifeSaverIIModeNumberOfEnnemiesToSpawn.y);
            }
            else if (difficulty == EDunjeonDifficulty.LifeSaverIII)
            {
                return Random.Range(m_lifeSaverIIIModeNumberOfEnnemiesToSpawn.x, m_lifeSaverIIIModeNumberOfEnnemiesToSpawn.y);
            }
            else if(difficulty == EDunjeonDifficulty.AbsoluteMasterGuardian)
            {
                return Random.Range(m_absoluteMasterGuardianModeNumberOfEnnemiesToSpawn.x, m_absoluteMasterGuardianModeNumberOfEnnemiesToSpawn.y);
            }
            Debug.LogError("No valid difficulty");
            return 0;
        }
    }
}