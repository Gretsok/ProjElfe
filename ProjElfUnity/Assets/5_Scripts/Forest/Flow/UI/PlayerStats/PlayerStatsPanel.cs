using UnityEngine;

namespace ProjElf.HubForest
{
    public class PlayerStatsPanel : Panel
    {
        [SerializeField]
        private PlayerStatsDisplay m_playerStatsDisplay = null;
        public override void Show()
        {
            base.Show();
            m_playerStatsDisplay.DisplayPlayerStats();
        }
    }
}