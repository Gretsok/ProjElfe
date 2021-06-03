using ProjElf.Interaction;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class InventoryChest : MonoBehaviour, IInteractable
    {

        private HubForestGameMode m_gamemode = null;

        [SerializeField]
        private Animator m_animator = null;
        private int OPEN = Animator.StringToHash("Open");

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

        public void OpenChest()
        {
            m_animator.SetBool(OPEN, true);
        }

        public void CloseChest()
        {
            m_animator.SetBool(OPEN, false);
        }
    }
}