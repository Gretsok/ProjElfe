using UnityEngine;
using MOtter.StatesMachine;
using System.Collections;
using UnityEngine.AI;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonGameMode : ProjElfGameMode
    {
        [SerializeField]
        private DunjeonManager m_dunjeonManager = null;
        public DunjeonManager DunjeonManager => m_dunjeonManager;

        public override IEnumerator LoadAsync()
        {
            #region Dunjeon Generation
            m_dunjeonManager.StartDunjeonGeneration();

            while(!m_dunjeonManager.DunjeonGenerated)
            {
                m_dunjeonManager.UpdateDunjeonGeneration();
                yield return 0;
            }
            m_dunjeonManager.GetComponent<NavMeshSurface>().BuildNavMesh();
            /*foreach (DunjeonRoom room in DunjeonManager.InstantiatedRooms)
            {
                room.ActivateRoom();
                yield return 0;
            }*/

            #endregion

            yield return base.LoadAsync();
        }

        protected override void EnterStateMachine()
        {
            base.EnterStateMachine();
            Debug.Log("GM READY");
        }

        public override void DoUpdate()
        {
            base.DoUpdate();
            foreach(DunjeonRoom room in DunjeonManager.InstantiatedRooms)
            {
                room.UpdateAIInRoom();
            }
        }

        public override void DoFixedUpdate()
        {
            base.DoUpdate();
            foreach (DunjeonRoom room in DunjeonManager.InstantiatedRooms)
            {
                room.FixedUpdateAIInRoom();
            }
            if(Physics.Raycast(m_player.transform.position, Vector3.down, out RaycastHit hitInfo))
            {
                if(hitInfo.transform.TryGetComponent<DunjeonRoom>(out DunjeonRoom room))
                {
                    room.ActivateRoom();
                }
            }
        }

        public override void DoLateUpdate()
        {
            base.DoUpdate();
            foreach (DunjeonRoom room in DunjeonManager.InstantiatedRooms)
            {
                room.LateUpdateAIInRoom();
            }
        }
    }
}