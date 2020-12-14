using MOtter.StatesMachine;
using ProjElf.PlayerController;
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

        public void Init()
        {
            EnterStateMachine();
        }

    }
}