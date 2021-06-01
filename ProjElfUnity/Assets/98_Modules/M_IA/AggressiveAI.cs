using ProjElf.CombatController;
using ProjElf.ProceduraleGeneration;
using System;
using UnityEngine;
using MOtter;
using System.Collections;

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

        [SerializeField]
        private RagdollActivator m_ragdollActivator = null;

        [SerializeField]
        private GenericAIGettingCloserToPlayerState m_beingAttackedState = null;

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_combatController.ForceContinueFiring = true;
            m_combatController.OnLifeReachedZero += Die;
            m_combatController.OnBeingAttacked += OnBeingAttacked;
        }

        private void OnBeingAttacked(Damage damage, CombatController.CombatController attacker)
        {
            SwitchToState(m_beingAttackedState);
        }

        internal override void ExitStateMachine()
        {
            m_combatController.OnLifeReachedZero -= Die;
            m_combatController.OnBeingAttacked -= OnBeingAttacked;
            base.ExitStateMachine();
        }

        public override void Init()
        {
            base.Init();
            m_gamemode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>();
            m_combatController.Init(m_gamemode);
            m_combatController.ResetStatsBonus();
            //GetComponent<EnnemyStatsImprovementsManager>().ImproveEnnemy(m_gamemode.DunjeonManager.CurrentDunjeonData.LifeFactor, m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor, m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor);

            m_combatController.MultiplyLifePointBy(m_gamemode.DunjeonManager.CurrentDunjeonData.LifeFactor);
            m_combatController.ImprovePhysicalDamageMultiplierIncrement(m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor);
            m_combatController.ImproveMagicalDamageMultiplierIncrement(m_gamemode.DunjeonManager.CurrentDunjeonData.DamageFactor);

        }

        private void Die()
        {
            Debug.Log("AI Died");
            StartCoroutine(DieRoutine(5f));
        }
        private IEnumerator DieRoutine(float timeToDisappear)
        {
            AttachedDunjeonRoom.RemoveAIToRoom(this);
            m_ragdollActivator.ActivateRagdoll();
            Agent.SetDestination(transform.position);
            m_combatController.CleanUp();

            yield return new WaitForSeconds(timeToDisappear);

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