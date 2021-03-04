using ProjElf.Interaction;
using ProjElf.SceneData;
using UnityEngine;

public class AdventureCrystal : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SceneData m_dunjeonSceneData = null;

    private bool m_loadingStarted = false;


    public void DoInteraction(Interactor interactor = null)
    {
        Debug.Log("Interact with crystal");
        if(!m_loadingStarted)
        {
            m_dunjeonSceneData.LoadLevel();
            m_loadingStarted = true;
        }
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
