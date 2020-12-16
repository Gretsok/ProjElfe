using MOtter;
using MOtter.StatesMachine;
using ProjElf.PlayerController;
using ProjElf.ProceduraleGeneration;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace ProjElf.AI
{
    public class GenericAI : StatesMachine
    {
        [System.Serializable]
        struct StateToActivateCloseToPlayerData
        {
            [Tooltip("Type the squared distance (for optimization purpose)")]
            public float m_sqrDistanceToPlayer;
            public GenericAIState m_stateToActivate;
        }

        [SerializeField]
        private Player m_player = null;
        [SerializeField]
        private NavMeshAgent m_agent = null;
        [SerializeField, Tooltip("The lower the index is, the higher its priority is")]
        private List<StateToActivateCloseToPlayerData> m_listOfStatesToActivateWhenCloseToPlayer = new List<StateToActivateCloseToPlayerData>();

        public Player Player => m_player;
        public NavMeshAgent Agent => m_agent;

        private DunjeonRoom m_attachedDunjeonRoom = null;
        public DunjeonRoom AttachedDunjeonRoom => m_attachedDunjeonRoom;

        public void Init(DunjeonRoom attachedDunjeonRoom)
        {
            m_attachedDunjeonRoom = attachedDunjeonRoom;
            m_player = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>().Player;
            EnterStateMachine();
            
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
            ManageStateToActivate();
        }

        public void ManageStateToActivate()
        {
            GenericAIState stateToSwitchTo = null;
            for(int i = m_listOfStatesToActivateWhenCloseToPlayer.Count - 1; i >= 0; --i)
            {
                if((m_player.transform.position - transform.position).sqrMagnitude < m_listOfStatesToActivateWhenCloseToPlayer[i].m_sqrDistanceToPlayer)
                {
                    stateToSwitchTo = m_listOfStatesToActivateWhenCloseToPlayer[i].m_stateToActivate;
                }
            }
            if(stateToSwitchTo != null && stateToSwitchTo != m_currentState)
            {
                SwitchToState(stateToSwitchTo);
            }
        }

    }

    
}