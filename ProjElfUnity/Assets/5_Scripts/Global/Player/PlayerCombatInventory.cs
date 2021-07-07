using ProjElf.CombatController;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerCombatInventory : CombatController.CombatInventory
    {
        [SerializeField]
        private Player m_player = null;
        public override void ChangeBow(BowData.BowSaveData newBowData)
        {
            base.ChangeBow(newBowData);
            if(m_bow != null)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.InflateBow(m_bow.WeaponSaveData as BowData.BowSaveData);
            }
        }

        public override void ChangeGrimoire(GrimoireData.GrimoireSaveData newGrimoireData)
        {
            base.ChangeGrimoire(newGrimoireData);
            if(m_grimoire != null)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.InflateGrimoire(m_grimoire.WeaponSaveData as GrimoireData.GrimoireSaveData);
            }

        }

        public override void ChangeMeleeWeapon(MeleeWeaponData.MeleeWeaponSaveData newMeleeWeaponData)
        {
            base.ChangeMeleeWeapon(newMeleeWeaponData);
            if(m_meleeWeapon != null)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.InflateMeleeWeapon(m_meleeWeapon.WeaponSaveData as MeleeWeaponData.MeleeWeaponSaveData);
            }
        }

        public override void SelectBow()
        {
            base.SelectBow();
            (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetBowActive();
        }

        public override void SelectGrimoire()
        {
            base.SelectGrimoire();
            (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetGrimoireActive();
        }

        public override void SelectMeleeWeapon()
        {
            base.SelectMeleeWeapon();
            (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetMeleeWeaponActive();
        }

        public override void SelectNextWeapon()
        {
            base.SelectNextWeapon();
            if (m_selectedWeapon.WeaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetMeleeWeaponActive();
            }
            else if (m_selectedWeapon.WeaponSaveData is GrimoireData.GrimoireSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetGrimoireActive();
            }
            else if (m_selectedWeapon.WeaponSaveData is BowData.BowSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetBowActive();
            }
        }

        public override void SelectPreviousWeapon()
        {
            base.SelectPreviousWeapon();
            if (m_selectedWeapon.WeaponSaveData is MeleeWeaponData.MeleeWeaponSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetMeleeWeaponActive();
            }
            else if (m_selectedWeapon.WeaponSaveData is GrimoireData.GrimoireSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetGrimoireActive();
            }
            else if (m_selectedWeapon.WeaponSaveData is BowData.BowSaveData)
            {
                (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetBowActive();
            }
        }

        public override void UnEquipWeapon()
        {
            base.UnEquipWeapon();
            (m_combatController.UIManager as PlayerController.PlayerCombatControllerUIManager).WeaponsDisplay.SetNoWeaponActive();
        }

        public override void UseMeleeWeapon()
        {
            base.UseMeleeWeapon();

        }
    }
}