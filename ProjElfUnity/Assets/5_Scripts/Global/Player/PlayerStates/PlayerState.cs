using MOtter.StatesMachine;
using UnityEngine;

namespace ProjElf.PlayerController
{
    public class PlayerState : State
    {
        [SerializeField]
        protected Player m_player = null;
        protected virtual void SetUpInputs()
        {

        }

        protected virtual void CleanUpInputs()
        {

        }

        public override void EnterState()
        {
            base.EnterState();
            SetUpInputs();
        }

        public override void ExitState()
        {
            CleanUpInputs();
            base.ExitState();
        }
    }
}