﻿using ProjElf.CombatController;
using ProjElf.Interaction;
using UnityEngine;

public class EquipGrimoireInteractable : MonoBehaviour, IInteractable
{
    [SerializeField]
    private GrimoireData m_grimoireData = null;
    public void DoInteraction(Interactor interactor)
    {
        interactor?.GetComponent<CombatController>()?.CombatInventory.ChangeGrimoire(m_grimoireData.GetWeaponSaveData<GrimoireData.GrimoireSaveData>());
    }

    public void StartBeingWatched(Interactor interactor)
    {
    }

    public void StopBeingWatched(Interactor interactor)
    {
    }
}
