using ProjElf.CombatController;

using UnityEngine;


public class CharacterEventRelay : MonoBehaviour
{

    [SerializeField]
    private CombatInventory m_combatInventory = null;

    public virtual void StartSwordAttack()
    {
        m_combatInventory.MeleeWeapon.StartDamaging();
        
    }

    public virtual void StopSwordAttack()
    {
        m_combatInventory.MeleeWeapon.StopDamaging();
    }

    public virtual void Step()
    {

    }

}
