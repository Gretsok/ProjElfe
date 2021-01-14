using System.Collections.Generic;
using UnityEngine;

namespace MOtter.StatesMachine
{
    public class UIState : State
    {
        [SerializeField] private Panel[] m_panels = null;

        public override void EnterState()
        {
            base.EnterState();
            for (int i = 0; i < m_panels.Length; i++)
            {
                m_panels[i].Show();
            }
        }

        public T GetPanel<T>() where T : Panel
        {
            for(int i = 0; i < m_panels.Length; ++i)
            {
                if(m_panels[i] is T)
                {
                    return m_panels[i] as T;
                }
            }
            return null;
        }

        public List<T> GetPanels<T>() where T : Panel
        {
            List<T> panelsToReturn = new List<T>();
            for(int i = 0; i < m_panels.Length; ++i)
            {
                if (m_panels[i] is T)
                {
                    panelsToReturn.Add(m_panels[i] as T);
                }
            }
            return panelsToReturn;
        }

        public override void ExitState()
        {
            for (int i = 0; i < m_panels.Length; i++)
            {
                m_panels[i].Hide();
            }
            base.ExitState();
        }
    }
}