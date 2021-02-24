using ProjElf.Interaction;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryChest : MonoBehaviour, IInteractable
{
    [SerializeField]
    private InventoryPanel m_inventoryPanel = null;

    public void DoInteraction(Interactor interactor)
    {
        m_inventoryPanel.Show();
    }

    public void StartBeingWatched()
    {
    }

    public void StopBeingWatched()
    {
    }
}
