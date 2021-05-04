
using UnityEngine.EventSystems;

namespace ProjElf.MainMenu
{ 
    public class CreateCharacterButtonNavigationPosition : ButtonNavigationPosition
    {
        protected override void Start()
        {
            base.Start();

            m_state = m_mainStatesMachine.CreateCharacterState;
        }

        public override void OnSelected()
        {
            base.OnSelected();
            m_mainStatesMachine.ProfileManager.InflateNewData();
        }
    }
}