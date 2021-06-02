using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class PlayerStatsInteractable : MonoBehaviour, IInteractable
    {
        HubForestGameMode m_gamemode = null;

        private void Start()
        {
            m_gamemode = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<HubForestGameMode>();
        }

        public void DoInteraction(Interactor interactor)
        {
            m_gamemode.ActivatePlayerDisplay();
        }

        public void StartBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).ShowPossibleInteraction("INTERACT_DISPLAY_PLAYER_STATS", null);
        }

        public void StopBeingWatched(Interactor interactor)
        {
            (interactor.GetComponent<PlayerController.Player>().CombatController.UIManager as PlayerController.PlayerCombatControllerUIManager).HidePossibleInteraction();
        }
    }
}