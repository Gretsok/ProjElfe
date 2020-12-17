using ProjElf.CombatController;
using UnityEngine;

namespace ProjElf.AI
{
    public class AggressiveAI : GenericAI
    {
        [SerializeField]
        private CombatController.CombatController m_combatController = null;
        public CombatController.CombatController CombatController => m_combatController;
    }
}