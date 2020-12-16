using ProjElf.Interaction;
using ProjElf.SceneData;
using UnityEngine;

public class AdventureCrystal : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SceneData m_dunjeonSceneData = null;

    public void DoInteraction()
    {
        Debug.Log("Interact with crystal");
        m_dunjeonSceneData.LoadLevel();
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
