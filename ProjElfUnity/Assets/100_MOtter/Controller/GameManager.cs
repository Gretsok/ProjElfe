using ProjElf.SceneData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOtter.StatesMachine
{
    public class GameManager : MonoBehaviour
    {
#if UNITY_EDITOR
        private DebugData m_debugData = null;
#endif

        private bool m_isInLoadingScreen = false;


        private MainStatesMachine m_mainStatesMachine = null;
        private List<SceneData> m_currentSceneData = new List<SceneData>();

        private SaveDataManager m_saveDataManager = null;
        public SaveDataManager SaveDataManager => m_saveDataManager;

        private SaveData m_currentSaveData = null;


        private void Start()
        {
            //MOtterApplication.GetInstance().PLAYERPROFILES.Init();
            m_saveDataManager = new SaveDataManager();
            m_saveDataManager.Load();

#if UNITY_EDITOR
            // Get Debug Data and register the default SceneData
            m_debugData = Resources.Load<DebugData>("DebugData");

            RegisterNewLevel(m_debugData.DefaultSceneData);
            if(m_debugData.DefaultSceneData != null)
                m_debugData.DefaultSceneData.LoadLevel();
            if (m_debugData.UseDefaultSaveData)
            {
                UseSaveData(m_debugData.DefaultSaveData);
            }
#endif

        }

        private void Update()
        {
            if (m_mainStatesMachine != null)
            {
                if(m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoUpdate();
                }  
            }
            //MOtterApplication.GetInstance().SOUND.CheckIfAudioSourcesPlayingStoppedPlaying();
        }

        private void FixedUpdate()
        {
            if (m_mainStatesMachine != null)
            {
                if (m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoFixedUpdate();
                }
            }
        }

        private void LateUpdate()
        {
            if (m_mainStatesMachine != null)
            {
                if (m_mainStatesMachine.IsLoaded)
                {
                    m_mainStatesMachine.DoLateUpdate();
                }
            }
        }

        public void RegisterNewMainStateMachine(MainStatesMachine statesmachine)
        {
            m_mainStatesMachine = statesmachine;
            StartCoroutine(statesmachine.LoadAsync());
            
        }

        public T GetCurrentMainStateMachine<T>() where T : MainStatesMachine
        {
            if (m_mainStatesMachine != null)
            {
                return (T)m_mainStatesMachine;
            }
            else
            {
                return null;
            }

        }

        #region SceneDataManagement
        public void RegisterNewLevel(SceneData sceneData)
        {
            m_currentSceneData.Add(sceneData);
        }
        #endregion

        #region SaveManagement
        public void UseSaveData(SaveData saveData)
        {
            m_currentSaveData = saveData;
        }

        public void SaveCurrentData()
        {
            if(m_currentSaveData != null)
            {
                m_saveDataManager.SaveSaveData(m_currentSaveData);
            }
        }

        public T GetSaveData<T>() where T : SaveData
        {
            return (m_currentSaveData as T);
        }
        #endregion
    }
}