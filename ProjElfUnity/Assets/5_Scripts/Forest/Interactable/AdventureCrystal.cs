using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class AdventureCrystal : MonoBehaviour, IInteractable
    {
        private HubForestGameMode m_gamemode = null;
        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }
        public void DoInteraction(Interactor interactor = null)
        {
            Debug.Log("Interact with crystal");
            m_gamemode.ActivateDunjeonSelectionState();
        }

        public void StartBeingWatched(Interactor iteractor)
        {
            Debug.Log("Crystal start being watched");
        }

        public void StopBeingWatched(Interactor iteractor)
        {
            Debug.Log("Crystal stop being watched");
        }
    }
}