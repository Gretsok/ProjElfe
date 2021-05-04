using ProjElf.CombatController;
using UnityEngine;

namespace ProjElf.MainMenu
{
    public class CharacterModel : MonoBehaviour
    {
        [SerializeField]
        private CombatController.CombatInventory m_combatInventory = null;

        internal void InflateSaveData(SaveData saveData)
        {
            m_combatInventory.DestroyMeleeWeapon();
            m_combatInventory.DestroyGrimoire();
            m_combatInventory.DestroyBow();
            m_combatInventory.ChangeBow(saveData.SavedPlayerWeaponInventory.EquippedBow);
            m_combatInventory.ChangeGrimoire(saveData.SavedPlayerWeaponInventory.EquippedGrimoire);
            m_combatInventory.ChangeMeleeWeapon(saveData.SavedPlayerWeaponInventory.EquippedMeleeWeapon);
        }

        internal void InflateWeapons(BowData.BowSaveData bowData, MeleeWeaponData.MeleeWeaponSaveData meleeWeaponData, GrimoireData.GrimoireSaveData grimoireData)
        {
            m_combatInventory.DestroyMeleeWeapon();
            m_combatInventory.DestroyGrimoire();
            m_combatInventory.DestroyBow();
            m_combatInventory.ChangeBow(bowData);
            m_combatInventory.ChangeGrimoire(grimoireData);
            m_combatInventory.ChangeMeleeWeapon(meleeWeaponData);
        }
    }
}