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
        private const float m_checkRoomDelay = 1f;
        private float m_lastTimeCheckedRoom = float.MinValue;

        [SerializeField]
        private Player m_player = null;
        [SerializeField]
        private NavMeshAgent m_agent = null;

        public Player Player => m_player;
        public NavMeshAgent Agent => m_agent;

        private DunjeonRoom m_attachedDunjeonRoom = null;
        public DunjeonRoom AttachedDunjeonRoom => m_attachedDunjeonRoom;

        public virtual void InitAsADunjeonAI(DunjeonRoom attachedDunjeonRoom)
        {
            m_attachedDunjeonRoom = attachedDunjeonRoom;
            Init();
        }

        public virtual void Init()
        {
            m_player = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<ProjElfGameMode>().Player;
            EnterStateMachine();
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
        }

        public override void DoFixedUpdate()
        {
            base.DoFixedUpdate();
            if(Time.time - m_lastTimeCheckedRoom > m_checkRoomDelay)
            {
                if (Physics.Raycast(transform.position + Vector3.up, Vector3.down, out RaycastHit hitInfo, 3f))
                {
                    if(hitInfo.transform.TryGetComponent<DunjeonRoomCollisionRelay>(out DunjeonRoomCollisionRelay collisionRelay))
                    {
                        if(collisionRelay.DunjeonRoom != m_attachedDunjeonRoom)
                        {
                            m_attachedDunjeonRoom.RemoveAIToRoom(this);
                            m_attachedDunjeonRoom = collisionRelay.DunjeonRoom;
                            m_attachedDunjeonRoom.AddAIToRoom(this);
                        }
                    }
                }
            }
            
        }
    }

    
}