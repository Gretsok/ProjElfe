using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.IndependantObject
{
    public class IndependantObjectManager : MonoBehaviour
    {
        #region MonoBehaviour Singleton
        protected static IndependantObjectManager s_instance = null;
        protected static IndependantObjectManager GetInstance()
        {
            if(s_instance == null)
            {
                GameObject go_manager = new GameObject();
                go_manager.name = "IndependantObjectManager";
                s_instance = go_manager.AddComponent<IndependantObjectManager>();
            }
            return s_instance;
        }
        public static IndependantObjectManager Instance => GetInstance();
        #endregion

        protected List<IndependantObject> m_independantObjects = new List<IndependantObject>();
        public void RegisterNewIndependantObject(IndependantObject a_independantObject)
        {
            m_independantObjects.Add(a_independantObject);
        }
        public void UnregisterIndependantObject(IndependantObject a_independantObject)
        {
            m_independantObjects.Remove(a_independantObject);
        }

        private void Update()
        {
            for(int i = m_independantObjects.Count - 1; i >= 0; --i)
            {
                try
                {
                    m_independantObjects[i].DoUpdate();
                }
                catch(System.Exception)
                {
                    m_independantObjects.Remove(m_independantObjects[i]);
                }
            }
        }

        private void FixedUpdate()
        {
            for (int i = m_independantObjects.Count - 1; i >= 0; --i)
            {
                try
                {
                    m_independantObjects[i].DoFixedUpdate();
                }
                catch (System.Exception)
                {
                    m_independantObjects.Remove(m_independantObjects[i]);
                }
            }
        }

        private void LateUpdate()
        {
            for (int i = m_independantObjects.Count - 1; i >= 0; --i)
            {
                try
                {
                    m_independantObjects[i].DoLateUpdate();
                }
                catch (System.Exception)
                {
                    m_independantObjects.Remove(m_independantObjects[i]);
                }
            }
        }
    }
}