using ProjElf.AnimalManagement;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerStatsImprovementsManager : MonoBehaviour
    {
        [SerializeField]
        private PlayerCombatController m_combatController = null;

        public void ImprovePlayer(List<RescuedAnimalData> a_rescuedAnimal)
        {
            ResetImprovements();
            foreach(RescuedAnimalData data in a_rescuedAnimal)
            {
                float increaseValue = data.AnimalData.StatToIncreaseAmount;
                switch (data.AnimalData.StatsToIncrease)
                {
                    case EPlayerStats.AttackSpeed:
                        ImproveAttackSpeed(increaseValue);
                        break;
                    case EPlayerStats.LifePoints:
                        ImproveLifePoints((int) increaseValue);
                        break;
                    case EPlayerStats.MovementSpeed:
                        ImproveMovementSpeed(increaseValue);
                        break;
                    case EPlayerStats.MagicalArmor:
                        ImproveMagicalArmor((int) increaseValue);
                        break;
                    case EPlayerStats.PhysicalArmor:
                        ImprovePhysicalArmor((int) increaseValue);
                        break;
                    case EPlayerStats.MagicalDamageMultiplierIncrement:
                        ImproveMagicalDamageMultiplierIncrement(increaseValue);
                        break;
                    case EPlayerStats.PhysicalDamageMultiplierIncrement:
                        ImprovePhysicalDamageMultiplierIncrement(increaseValue);
                        break;
                    default:
                        Debug.LogError($"stat \"{data.AnimalData.StatsToIncrease}\" is not handled");
                        break;
                }
            }
        }

        private void ResetImprovements()
        {
            m_combatController.ResetStatsBonus();
        }

        private void ImproveLifePoints(int lifePointsToAdd)
        {
            m_combatController.ImproveLifePointBy(lifePointsToAdd);
        }

        private void ImprovePhysicalDamageMultiplierIncrement(float multiplierIncrement)
        {
            m_combatController.ImprovePhysicalDamageMultiplierIncrement(multiplierIncrement);
        }

        private void ImproveMagicalDamageMultiplierIncrement(float multiplierIncrement)
        {
            m_combatController.ImproveMagicalDamageMultiplierIncrement(multiplierIncrement);
        }

        private void ImproveMovementSpeed(float movementSpeedIncrement)
        {

        }

        private void ImproveAttackSpeed(float attackSpeedIncrement)
        {
            m_combatController.ImproveAttackSpeed(attackSpeedIncrement);
        }

        private void ImprovePhysicalArmor(int armorToAdd)
        {
            m_combatController.ImprovePhysicalArmor(armorToAdd);
        }

        private void ImproveMagicalArmor(int armorToAdd)
        {
            m_combatController.ImproveMagicalArmor(armorToAdd);
        }
    }
}