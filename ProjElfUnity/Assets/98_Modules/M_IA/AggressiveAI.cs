using ProjElf.CombatController;
using UnityEngine;

namespace ProjElf.AI
{
    public class AggressiveAI : GenericAI
    {
        [SerializeField]
        private CombatController.CombatController m_combatController = null;
        public CombatController.CombatController CombatController => m_combatController;

        [SerializeField]
        private CharacterAnimatorHandler m_characterAnimatorHandler = null;
        public CharacterAnimatorHandler CharacterAnimatorHandler => m_characterAnimatorHandler;

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
            m_characterAnimatorHandler.SetForwardSpeed(Agent.velocity.magnitude / Agent.speed);
        }
    }
}