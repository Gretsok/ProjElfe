using MOtter.Localization;
using ProjElf.PlayerController;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class PlayerStatsDisplay : MonoBehaviour
    {
        [SerializeField]
        private TextLocalizer m_lifePointsLocalizer = null;
        [SerializeField]
        private TextLocalizer m_physicalDamageMultiplierIncrementLocalizer = null;
        [SerializeField]
        private TextLocalizer m_magicalDamageMultiplierIncrementLocalizer = null;
        [SerializeField]
        private TextLocalizer m_movementSpeedLocalizer = null;
        [SerializeField]
        private TextLocalizer m_attackSpeedLocalizer = null;
        [SerializeField]
        private TextLocalizer m_physicalArmorLocalizer = null;
        [SerializeField]
        private TextLocalizer m_magicalArmorLocalizer = null;


        public void DisplayPlayerStats()
        {
            ProjElfGameMode gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>();

            Player player = gamemode.Player;

            DisplayLifePoints(player);
            DisplayPhysicalDamageMultiplierIncrement(player);
            DisplayMagicalDamageMultiplierIncrement(player);
            DisplayMovementSpeed(player);
            DisplayAttackSpeed(player);
            DisplayPhysicalArmor(player);
            DisplayMagicalArmor(player);
        }

        private void DisplayLifePoints(Player player)
        {
            m_lifePointsLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.LifePoints));
            m_lifePointsLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.MaxLifePoints}";
            });
        }
        private void DisplayPhysicalDamageMultiplierIncrement(Player player)
        {
            m_physicalDamageMultiplierIncrementLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.PhysicalDamageMultiplierIncrement));
            m_physicalDamageMultiplierIncrementLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.PhysicalDamageMultiplierIncrement}";
            });
        }
        private void DisplayMagicalDamageMultiplierIncrement(Player player)
        {
            m_magicalDamageMultiplierIncrementLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.MagicalDamageMultiplierIncrement));
            m_magicalDamageMultiplierIncrementLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.MagicalDamageMultiplierIncrement}";
            });
        }
        private void DisplayMovementSpeed(Player player)
        {
            m_movementSpeedLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.MovementSpeed));
            m_movementSpeedLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : {player.MovingSpeed}";
            });
        }
        private void DisplayAttackSpeed(Player player)
        {
            m_attackSpeedLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.AttackSpeed));
            m_attackSpeedLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.AttackSpeedBonus}";
            });
        }
        private void DisplayPhysicalArmor(Player player)
        {
            m_physicalArmorLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.PhysicalArmor));
            m_physicalArmorLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.PhysicalArmor}";
            });
        }
        private void DisplayMagicalArmor(Player player)
        {
            m_magicalArmorLocalizer.SetKey(ProjElfUtils.GetPlayerStatKey(EPlayerStats.MagicalArmor));
            m_magicalArmorLocalizer.SetFormatter((text, localizer) =>
            {
                localizer.TextTarget.text = $"{text} : +{player.CombatController.MagicalArmor}";
            });
        }
    }
}