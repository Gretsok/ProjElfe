using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObjectPool
{
    public class ObjectPool : MonoBehaviour
    {
        private List<IPoolable> m_instantiatedObjects = new List<IPoolable>();

        /// <summary>
        /// Set IsPoolable to false manually
        /// </summary>
        /// <returns></returns>
        public T GetObject<T>(GameObject objectPrefab) where T : IPoolable
        {
            for(int i = 0; i < m_instantiatedObjects.Count; ++i)
            {
                if(m_instantiatedObjects[i].IsPoolable && m_instantiatedObjects[i] is T)
                {
                    return (T) m_instantiatedObjects[i];
                }
            }
            var newElement = Instantiate(objectPrefab).GetComponent<T>();
            m_instantiatedObjects.Add(newElement);
            return newElement;
        }
    }
}