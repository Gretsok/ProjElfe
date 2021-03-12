using UnityEngine;

namespace ObjectPool
{
    public interface IPoolable
    {
        bool IsPoolable { get; }
        GameObject gameObject { get; }
    }
}