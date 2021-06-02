using ProjElf.CombatController;
using ProjElf.Interaction;
using UnityEngine;

public class EquipBowInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private BowData m_bowData = null;
    public void DoInteraction(Interactor interactor)
    {
        interactor?.GetComponent<CombatController>()?.CombatInventory.ChangeBow(m_bowData.GetWeaponSaveData<BowData.BowSaveData>());
    }

    public void StartBeingWatched(Interactor interactor)
    {
    }

    public void StopBeingWatched(Interactor interactor)
    {
    }
}
