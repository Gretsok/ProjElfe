using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class AdventurePortal : MonoBehaviour, IInteractable
    {
        private HubForestGameMode m_gamemode = null;
        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }
        public void DoInteraction(Interactor interactor = null)
        {
            Debug.Log("Interact with portal");
            
        }

        public void StartBeingWatched(Interactor iteractor)
        {
            Debug.Log("Portal start being watched");
        }

        public void StopBeingWatched(Interactor iteractor)
        {
            Debug.Log("Portal stop being watched");
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject == m_gamemode.Player.gameObject)
                m_gamemode.ActivateDunjeonSelectionState();
        }
    }
}