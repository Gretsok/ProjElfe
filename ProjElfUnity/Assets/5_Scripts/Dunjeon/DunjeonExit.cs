using ProjElf.Interaction;
using ProjElf.ProceduraleGeneration;
using ProjElf.SceneData;
using UnityEngine;

public class DunjeonExit : MonoBehaviour, IInteractable
{
    public void DoInteraction(Interactor interactor = null)
    {
        MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<DunjeonGameMode>().WinDunjeon();
    }

    public void StartBeingWatched()
    {
    }

    public void StopBeingWatched()
    {
    }
}
