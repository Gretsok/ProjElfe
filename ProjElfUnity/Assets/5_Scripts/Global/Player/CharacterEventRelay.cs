using ProjElf.CombatController;

using UnityEngine;

public class CharacterEventRelay : MonoBehaviour
{
    [SerializeField]
    private CombatInventory m_combatInventory = null;

    public void StartSwordAttack()
    {
        m_combatInventory.MeleeWeapon.StartDamaging();
    }

    public void StopSwordAttack()
    {
        m_combatInventory.MeleeWeapon.StopDamaging();
    }
}
