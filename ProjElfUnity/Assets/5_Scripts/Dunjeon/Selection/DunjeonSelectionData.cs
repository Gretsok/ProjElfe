using ProjElf.ProceduraleGeneration;
using UnityEngine;

namespace ProjElf.HubForest
{
    [CreateAssetMenu(fileName = "DunjeonSelectionData", menuName = "Dunjeon/DunjeonSelectionData")]
    public class DunjeonSelectionData : ScriptableObject
    {
        [SerializeField]
        private string m_dunjeonNameKey = string.Empty;
        [SerializeField]
        private EDunjeonType m_dunjeonType = EDunjeonType.Castle;
        [SerializeField]
        private EDunjeonDifficulty m_dunjeonDifficulty = EDunjeonDifficulty.RescuerI;
        [SerializeField]
        private Sprite m_dunjeonIcon = null;
        [SerializeField]
        private SceneData.SceneData m_dunjeonSceneData = null;
        [SerializeField]
        private DunjeonData m_dunjeonData = null;

        public string DunjeonNameKey => m_dunjeonNameKey;
        public EDunjeonType DunjeonType => m_dunjeonType;
        public EDunjeonDifficulty DunjeonDifficulty => m_dunjeonDifficulty;
        public Sprite DunjeonIcon => m_dunjeonIcon;
        public SceneData.SceneData DunjeonSceneData => m_dunjeonSceneData;
        public DunjeonData DunjeonData => m_dunjeonData;
    }
}