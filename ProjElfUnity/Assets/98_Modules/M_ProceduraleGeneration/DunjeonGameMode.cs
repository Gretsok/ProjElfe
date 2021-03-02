using UnityEngine;
using MOtter.StatesMachine;
using System.Collections;
using UnityEngine.AI;
using MOtter;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonGameMode : ProjElfGameMode
    {
        [SerializeField]
        private DunjeonManager m_dunjeonManager = null;
        public DunjeonManager DunjeonManager => m_dunjeonManager;

        [SerializeField]
        private SceneData.SceneData m_hubSceneData = null;

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
            yield return 0;
            InstantiatePlayer();

            yield return base.LoadAsync();
        }

        internal override void EnterStateMachine()
        {
            base.EnterStateMachine();
            Debug.Log("GM READY");
        }

        public override void DoUpdate()
        {
            base.DoUpdate();
            foreach(DunjeonRoom room in DunjeonManager.RoomsToUpdate)
            {
                room.UpdateAIInRoom();
            }
        }

        public override void DoFixedUpdate()
        {
            base.DoFixedUpdate();
            foreach (DunjeonRoom room in DunjeonManager.RoomsToUpdate)
            {
                room.FixedUpdateAIInRoom();
            }
            if(Physics.Raycast(m_player.transform.position, Vector3.down, out RaycastHit hitInfo))
            {
                if(hitInfo.transform.TryGetComponent<DunjeonRoom>(out DunjeonRoom room))
                {
                    room.ActivateSurroundingRooms();
                }
            }
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();
            foreach (DunjeonRoom room in DunjeonManager.RoomsToUpdate)
            {
                room.LateUpdateAIInRoom();
            }
        }

        public void WinDunjeon()
        {
            var saveData = MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();

            for(int i = 0; i < m_player.CombatController.CombatInventory.HoldedWeapons.Count; i++)
            {
                saveData.EarnNewWeapon(m_player.CombatController.CombatInventory.HoldedWeapons[i]);
            }
                
            m_player.CombatController.CombatInventory.HoldedWeapons.Clear();
            m_hubSceneData.LoadLevel();
        }
        
        public void LoseDunjeon()
        {
            m_player.CombatController.CombatInventory.HoldedWeapons.Clear();
            m_hubSceneData.LoadLevel();
        }
    }
}