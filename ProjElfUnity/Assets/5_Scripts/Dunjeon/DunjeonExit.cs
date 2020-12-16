using ProjElf.Interaction;
using ProjElf.SceneData;
using UnityEngine;

public class DunjeonExit : MonoBehaviour, IInteractable
{
    [SerializeField]
    private SceneData m_hubForestSceneData = null;
    public void DoInteraction()
    {
        m_hubForestSceneData.LoadLevel();
    }

    public void StartBeingWatched()
    {
    }

    public void StopBeingWatched()
    {
    }
}
