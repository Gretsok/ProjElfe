using UnityEngine;
using MOtter.StatesMachine;
using System.Collections;
using UnityEngine.AI;
using MOtter;
using ProjElf.DunjeonGameplay;
using ProjElf.AnimalManagement;

namespace ProjElf.ProceduraleGeneration
{
    public class DunjeonGameMode : ProjElfGameMode
    {
        [SerializeField]
        private DunjeonManager m_dunjeonManager = null;
        public DunjeonManager DunjeonManager => m_dunjeonManager;

        [SerializeField]
        private SceneData.SceneData m_hubSceneData = null;

        [Header("States")]
        [SerializeField]
        private DunjeonDeathState m_dunjeonDeathState = null;
        [SerializeField]
        private DunjeonRescuedAnimalState m_dunjeonRescuedAnimalState = null;

        private AnimalData m_animalDataToRescue = null;
        public AnimalData AnimalDataToRescue => m_animalDataToRescue;

        public override IEnumerator LoadAsync()
        {
            #region Dunjeon Generation

            m_dunjeonManager.SetDunjeonData(DunjeonDataTransmitter.DunjeonData);
            DunjeonDataTransmitter.DestroyCurrentInstance();


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


            yield return null;
            InstantiatePlayer();

            yield return null;
            m_dunjeonManager.InstantiatedRooms[0].ActivateSurroundingRooms();

            yield return null;
            AnimalPrison animalPrison = FindObjectOfType<AnimalPrison>();
            while(animalPrison.AnimalDataToRescue == null)
            {
                yield return null;
            }
            m_animalDataToRescue = animalPrison.AnimalDataToRescue;



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
                if(hitInfo.transform.TryGetComponent<DunjeonRoomCollisionRelay>(out DunjeonRoomCollisionRelay room))
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
            SavePlayerWeapons();
            SwitchToState(m_dunjeonRescuedAnimalState);
        }
        
        public void LoseDunjeon()
        {
            m_player.CombatController.CombatInventory.HoldedWeapons.Clear();
            SwitchToState(m_dunjeonDeathState);
        }

        public void LoadBackToHub()
        {
            m_hubSceneData.LoadLevel();
        }
    }
}