using UnityEngine;
using System.Collections;
using UnityEngine.AI;
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

        private DunjeonRoom m_playerCurrentDunjeonRoom = null;

        #region Specific Sounds Running
        private AudioSource m_musicAudioSource = null;
        private AudioSource m_ambianceAudioSource = null;
        #endregion

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
            animalPrison.Init(m_dunjeonManager.CurrentDunjeonData.DunjeonDifficulty);
            while(animalPrison.AnimalDataToRescue == null)
            {
                yield return null;
            }
            m_animalDataToRescue = animalPrison.AnimalDataToRescue;

            if(m_dunjeonManager.CurrentDunjeonData.MusicSoundData != null)
                m_musicAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(m_dunjeonManager.CurrentDunjeonData.MusicSoundData, true);
            if(m_dunjeonManager.CurrentDunjeonData.AmbianceSoundData)
                m_ambianceAudioSource = MOtter.MOtterApplication.GetInstance().SOUND.Play2DSound(m_dunjeonManager.CurrentDunjeonData.AmbianceSoundData, true);

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

        }

        public override void DoFixedUpdate()
        {
            base.DoFixedUpdate();

            if(Physics.Raycast(m_player.transform.position, Vector3.down, out RaycastHit hitInfo))
            {
                if(hitInfo.transform.TryGetComponent<DunjeonRoomCollisionRelay>(out DunjeonRoomCollisionRelay room))
                {
                    if(m_playerCurrentDunjeonRoom != room.DunjeonRoom)
                    {
                        room.ActivateSurroundingRooms();
                        m_playerCurrentDunjeonRoom = room.DunjeonRoom;
                    }
                }
            }
        }

        public override void DoLateUpdate()
        {
            base.DoLateUpdate();

        }

        public void WinDunjeon()
        {
            SaveData saveData = MOtter.MOtterApplication.GetInstance().GAMEMANAGER.GetSaveData<SaveData>();
            if (m_dunjeonManager.CurrentDunjeonData.DunjeonDifficulty == saveData.DifficultyToBeat)
            {
                saveData.DifficultyToBeat++;
            }
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

        internal override void ExitStateMachine()
        {
            if(m_musicAudioSource != null && m_musicAudioSource.isPlaying)
            {
                m_musicAudioSource.Stop();
            }
            if(m_ambianceAudioSource != null && m_ambianceAudioSource.isPlaying)
            {
                m_ambianceAudioSource.Stop();
            }
            base.ExitStateMachine();
        }
    }
}