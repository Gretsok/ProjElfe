using ProjElf.CombatController;
using ProjElf.Interaction;
using UnityEngine;

public class EquipMeleeWeaponInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private MeleeWeaponData m_meleeWeaponData = null;
    public void DoInteraction(Interactor interactor)
    {
        interactor?.GetComponent<CombatController>()?.CombatInventory.ChangeMeleeWeapon(m_meleeWeaponData);
    }

    public void StartBeingWatched()
    {

    }

    public void StopBeingWatched()
    {

    }
}
