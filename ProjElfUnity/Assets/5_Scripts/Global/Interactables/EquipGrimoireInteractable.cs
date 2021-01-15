using ProjElf.CombatController;
using ProjElf.Interaction;
using UnityEngine;

public class EquipGrimoireInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GrimoireData m_grimoireData = null;
    public void DoInteraction(Interactor interactor)
    {
        interactor?.GetComponent<CombatController>()?.CombatInventory.ChangeGrimoire(m_grimoireData);
    }

    public void StartBeingWatched()
    {
        
    }

    public void StopBeingWatched()
    {
        
    }

}
