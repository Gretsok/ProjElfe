using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerCombatController : CombatController.CombatController
    {
        internal void ResetStatsBonus()
        {
            m_maxLifePoints = m_baseMaxLifePoints;
            m_physicalArmor = 0;
            m_magicalArmor = 0;
            m_attackSpeedBonus = 0f;
            m_magicalDamageMultiplierIncrement = 0f;
            m_physicalDamageMultiplierIncrement = 0f;
        }

        internal void ImproveLifePointBy(int a_lifePointsToAdd)
        {
            m_maxLifePoints += a_lifePointsToAdd;
            Heal(a_lifePointsToAdd);
        }

        internal void ImprovePhysicalArmor(int armorToAdd)
        {
            m_physicalArmor += armorToAdd;
        }

        internal void ImproveMagicalArmor(int armorToAdd)
        {
            m_magicalArmor += armorToAdd;
        }

        internal void ImproveAttackSpeed(float attackSpeedToAdd)
        {
            m_attackSpeedBonus += attackSpeedToAdd;
        }

        internal void ImprovePhysicalDamageMultiplierIncrement(float increment)
        {
            m_physicalDamageMultiplierIncrement += increment;
        }

        internal void ImproveMagicalDamageMultiplierIncrement(float increment)
        {
            m_magicalDamageMultiplierIncrement += increment;
        }
    }
}