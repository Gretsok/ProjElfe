using UnityEngine;
using MOtter.StatesMachine;
using System.Collections;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonGameMode : PauseableStateMachine
    {
        [SerializeField]
        private DunjeonManager m_dunjeonManager = null;

        public override IEnumerator LoadAsync()
        {
            #region Dunjeon Generation
            m_dunjeonManager.StartDunjeonGeneration();

            while(!m_dunjeonManager.DunjeonGenerated)
            {
                m_dunjeonManager.UpdateDunjeonGeneration();
                yield return 0;
            }
            #endregion

            yield return base.LoadAsync();
        }

        protected override void EnterStateMachine()
        {
            base.EnterStateMachine();
            Debug.Log("GM READY");
        }
    }
}