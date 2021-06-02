using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class InventoryChest : MonoBehaviour, IInteractable
    {

        private HubForestGameMode m_gamemode = null;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }

        public void DoInteraction(Interactor interactor)
        {
            m_gamemode.ActivateInventoryState();
        }

        public void StartBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).ShowPossibleInteraction("INTERACT_OPEN_INVENTORY", null);
        }

        public void StopBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).HidePossibleInteraction();
        }
    }
}