using ProjElf.CombatController;
using ProjElf.ProceduraleGeneration;
using System;
using UnityEngine;
using MOtter;

namespace ProjElf.AI
{
    public class AggressiveAI : GenericAI
    {
        private DunjeonGameMode m_gamemode = null;

        [SerializeField]
        private CombatController.CombatController m_combatController = null;
        public CombatController.CombatController CombatController => m_combatController;

        [SerializeField]
        private CharacterAnimatorHandler m_characterAnimatorHandler = null;
        public CharacterAnimatorHandler CharacterAnimatorHandler => m_characterAnimatorHandler;

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_combatController.ForceContinueFiring = true;
            m_combatController.OnLifeReachedZero += Die;
        }

        public override void Init()
        {
            base.Init();
            m_combatController.ResetStatsBonus();
            m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
            m_combatController.ImprovePhysicalDamageMultiplierIncrement(m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor);
            m_combatController.ImproveMagicalDamageMultiplierIncrement(m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor);
        }

        private void Die()
        {
            Debug.Log("AI Died");
            AttachedDunjeonRoom.RemoveAIToRoom(this);
            Destroy(gameObject);
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
            m_characterAnimatorHandler.SetForwardSpeed(Agent.velocity.magnitude / Agent.speed);
            m_combatController.DoUpdate(transform.forward);
        }
    }
}