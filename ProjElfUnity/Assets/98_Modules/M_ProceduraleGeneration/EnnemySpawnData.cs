using UnityEngine;


namespace ProjElf.ProceduraleGeneration
{
    [System.Serializable]
    internal class EnnemySpawnData
    {
        [SerializeField, Tooltip("Prefab to spawn")]
        internal GameObject EnnemyPrefab = null;
        [SerializeField, Tooltip("The higher it is, the more chance it has to spawn")]
        internal int SpawnWeight = 0;
    }
}