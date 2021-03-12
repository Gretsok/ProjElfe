using MOtter.StatesMachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ProjElf.HubForest
{
    public class HubForestGameMode : ProjElfGameMode
    {
        [SerializeField]
        private ForestGameplayState m_gameplayState = null;
        [SerializeField]
        private ForestDunjeonSelectionState m_dunjeonSelectionState = null;
        [SerializeField]
        private ForestInventoryState m_inventoryState = null;

        private AudioSource m_ambianceAudioSource = null;

        public override IEnumerator LoadAsync()
        {
            yield return null;
            InstantiatePlayer();

            yield return base.LoadAsync();

        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            m_ambianceAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(ForestHubAudioReferences.Ambiance, true);
        }

        public void ActivateGameplayState()
        {
            SwitchToState(m_gameplayState);
        }

        public void ActivateDunjeonSelectionState()
        {
            SwitchToState(m_dunjeonSelectionState);
        }

        public void ActivateInventoryState()
        {
            SwitchToState(m_inventoryState);
        }

        internal override void ExitStateMachine()
        {
            MOtter.MOtterApplication.GetInstance().SOUND.CleanSource(m_ambianceAudioSource);
            base.ExitStateMachine();
        }

    }
}