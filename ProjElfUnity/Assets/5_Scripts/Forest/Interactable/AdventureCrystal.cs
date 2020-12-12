using ProjElf.Interaction;
using UnityEngine;

public class AdventureCrystal : MonoBehaviour, IInteractable
{
    public void DoInteraction()
    {
        Debug.Log("Interact with crystal");
    }

    public void StartBeingWatched()
    {
        Debug.Log("Crystal start being watched");
    }

    public void StopBeingWatched()
    {
        Debug.Log("Crystal stop being watched");
    }
}
