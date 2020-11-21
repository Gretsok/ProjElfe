using MOtter;
using UnityEngine;

public class ContextDemoZone : MonoBehaviour
{
    [SerializeField] private string zoneName = null;
    public int zoneNameHash;
    private void Awake()
    {
        zoneNameHash = MOtterApplication.GetInstance().UTILS.GetDeterministicHashCode(zoneName);
    }
}
