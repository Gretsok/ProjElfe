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

        [SerializeField]
        private Player m_player = null;
        [SerializeField]
        private NavMeshAgent m_agent = null;

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
        }
    }

    
}