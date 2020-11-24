using UnityEngine;


namespace ProjElf.ProceduraleGeneration
{
    [System.Serializable]
    internal class EnnemySpawnData
    {
        [SerializeField]
        internal GameObject EnnemyPrefab = null;
        [SerializeField]
        internal int SpawnWeight = 0;
    }
}