using ProjElf.SceneData;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace MOtter.StatesMachine
{
    public class GameManager : MonoBehaviour
    {
        [SerializeField]
        private SceneField[] m_loadingScreens = null;
        private string m_currentLoadingScreenSceneName = "";
        private bool m_isInLoadingScreen = false;

        private MainStatesMachine m_mainStatesMachine = null;
        private List<SceneData> m_currentSceneData = new List<SceneData>();

        private SaveDataManager m_saveDataManager = null;
        public SaveDataManager SaveDataManager => m_saveDataManager;

        private void Start()
        {
            //MOtterApplication.GetInstance().PLAYERPROFILES.Init();
            m_saveDataManager = new SaveDataManager();
            m_saveDataManager.Load();
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
            MOtterApplication.GetInstance().SOUND.CheckIfAudioSourcesPlayingStoppedPlaying();
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
            if (m_mainStatesMachine != null)
            {
                StartCoroutine(m_mainStatesMachine.UnloadAsync(null));
            }
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

        #region LoadingScreenManagement
        public void ActivateLoadingScreen()
        {
            if(!m_isInLoadingScreen)
            {
                Debug.Log("LOADING SCREEN");
                m_currentLoadingScreenSceneName = m_loadingScreens[(new System.Random((int)Time.time)).Next(0, m_loadingScreens.Length)];
                SceneManager.LoadSceneAsync(m_currentLoadingScreenSceneName, LoadSceneMode.Additive);
                m_isInLoadingScreen = true;
            }
            
        }
        public void DisactivateLoadingScreen()
        {
            if(m_isInLoadingScreen)
            {
                Debug.Log("END LOADING SCREEN");
                SceneManager.UnloadSceneAsync(m_currentLoadingScreenSceneName);
                m_isInLoadingScreen = false;
            }
        }
        #endregion

        #region SceneDataManagement
        public void RegisterNewLevel(SceneData sceneData)
        {
            m_currentSceneData.Add(sceneData);
        }

        public void UnloadScenesData()
        {
            // We unload all levels but the one we just added
            for (int i = 0; i < m_currentSceneData.Count - 1; i++)
            {
                m_currentSceneData[i].UnloadLevel();
            }
            SceneData lastAdded = m_currentSceneData[m_currentSceneData.Count - 1];
            m_currentSceneData.Clear();
            m_currentSceneData.Add(lastAdded);
        }
        #endregion
    }
}