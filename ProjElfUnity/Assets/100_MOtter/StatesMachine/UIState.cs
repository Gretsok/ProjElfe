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