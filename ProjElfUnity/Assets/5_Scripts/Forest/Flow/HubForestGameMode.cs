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
        public override IEnumerator LoadAsync()
        {
            yield return 0;
            InstantiatePlayer();
            yield return 0;
            yield return base.LoadAsync();

        }

        public void ActivateGameplayState()
        {
            SwitchToState(m_gameplayState);
        }

        public void ActivateDunjeonSelectionState()
        {
            SwitchToState(m_dunjeonSelectionState);
        }

    }
}