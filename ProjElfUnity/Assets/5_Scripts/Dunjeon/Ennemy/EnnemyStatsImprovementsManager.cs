using ProjElf.AnimalManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.AI
{
    public class EnnemyStatsImprovementsManager : MonoBehaviour
    {
        [SerializeField]
        private EnnemyCombatController m_combatController = null;
        [SerializeField]

        public void ImproveEnnemy(float increaseLifeValue, float increaseMagicDmgValue, float increasePhysicDmgValue)
        {
            ResetImprovements();
            ImproveLifePoints(increaseLifeValue);
            ImproveMagicalDamageMultiplierIncrement(increaseMagicDmgValue);
            ImprovePhysicalDamageMultiplierIncrement(increasePhysicDmgValue);
            //Debug.LogError("One of the stat make tout cassé");
        }

        private void ResetImprovements()
        {
            m_combatController.ResetStatsBonus();
        }

        private void ImproveLifePoints(float lifePointsToAdd)
        {
            m_combatController.MultiplyLifePointBy(lifePointsToAdd);
        }

        private void ImprovePhysicalDamageMultiplierIncrement(float multiplierIncrement)
        {
            m_combatController.ImprovePhysicalDamageMultiplierIncrement(multiplierIncrement);
        }

        private void ImproveMagicalDamageMultiplierIncrement(float multiplierIncrement)
        {
            m_combatController.ImproveMagicalDamageMultiplierIncrement(multiplierIncrement);
        }
    }
}