using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOtter;
using UnityEngine.SceneManagement;
using System;
using MOtter.StatesMachine;

namespace ProjElf.SceneData
{
    [CreateAssetMenu(fileName = "LevelData", menuName = "Levels/LevelData")]
    public class SceneData : ScriptableObject
    {
        /// <summary>
        /// la scène qui contiendra la machine d’états principale de la scène
        /// </summary>

        [SerializeField] private SceneField m_mainScene = null;

        /// <summary>
        ///  Les additionalScenes sont également chargés, à noter que la première scène d’additionalScenes sera l’ActiveScene, elle devra donc contenir l’environnement de la scène à charger. Si il n’y a pas d’additionalScene, c’est la mainScene qui sera en Active.
        /// </summary>

        [SerializeField] private SceneField[] m_additionalScenes = null;

        [SerializeField] private SceneField m_loadingScreen = null;
        private bool m_loadingScreenActive = false;

       
        [SerializeField] private string m_levelName = null;

        //reference vers m_levelName
        public string LevelName=>m_levelName;

        [SerializeField] private LoadSceneMode m_defaultLoadMode = LoadSceneMode.Additive;
        private LoadSceneMode m_currentLoadSceneMode;
        private Scene sceneToActivate;

        AsyncOperation op;

        #region LevelLoading
        public void LoadLevel()
        {
            //passe le m_default
            LoadLevel(m_defaultLoadMode);
        }

        public void LoadLevel(LoadSceneMode loadMode)
        {
            op = null;
            
            m_currentLoadSceneMode = loadMode;
            MOtterApplication.GetInstance().StartCoroutine(StartLoadLevelRoutine());
        }

        IEnumerator StartLoadLevelRoutine()
        {
            yield return null;
            var currentGameMode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>();
            if (currentGameMode != null)
            {
                if(!m_loadingScreenActive && m_loadingScreen.SceneName != "")
                {
                    op = SceneManager.LoadSceneAsync(m_loadingScreen.SceneName, LoadSceneMode.Additive);
                    while(!op.isDone)
                    {
                        yield return null;
                    }
                    m_loadingScreenActive = true;
                }


                yield return currentGameMode.UnloadAsync(LoadScenes);

            }
            else
            {
                LoadScenes();
            }
        }

        private void LoadScenes()
        {
            //On load une scene(main + additionalScenes[])
            MOtterApplication.GetInstance().GAMEMANAGER.RegisterNewLevel(this);
            List<Scene> currentScenes = new List<Scene>();
            for(int i = 0; i< SceneManager.sceneCount; ++i)
            {
                Scene sceneToAdd = SceneManager.GetSceneAt(i);
                if(sceneToAdd.name != m_loadingScreen.SceneName)
                {
                    currentScenes.Add(sceneToAdd);
                }
                
            }
            MOtterApplication.GetInstance().StartCoroutine(LoadScenes(currentScenes.ToArray()));
            
        }

        IEnumerator LoadScenes(Scene[] loadedScenes)
        {
            yield return null;
            op = SceneManager.LoadSceneAsync(m_mainScene.SceneName, LoadSceneMode.Additive);
            Debug.Log("LOADING " + m_mainScene.SceneName);

            if(m_currentLoadSceneMode == LoadSceneMode.Single)
            {
                while (!op.isDone)
                {
                    yield return null;
                }

                for(int i = 0; i < loadedScenes.Length; ++i)
                {
                    op = SceneManager.UnloadSceneAsync(loadedScenes[i]);
                    while (!op.isDone)
                    {
                        yield return null;
                    }
                }

            }

            


            MOtterApplication.GetInstance().StartCoroutine(LoadAdditionalScenes());
            
        }

        IEnumerator LoadAdditionalScenes()
        {
            yield return null;
            while(!op.isDone)
            {
                yield return null;
            }
            //charger additionalScenes 
            for (int i = 0; i < m_additionalScenes.Length; i++)
            {
                op = SceneManager.LoadSceneAsync(m_additionalScenes[i].SceneName, LoadSceneMode.Additive);//empeche la supperssion de la scene precedente
                while(!op.isDone)
                {
                    yield return null;
                }
            }
            if (m_additionalScenes.Length == 0)// Si il n'y a pas d'additional scene -> m_main sera la principale 
            {
                sceneToActivate = SceneManager.GetSceneByName(m_mainScene.SceneName);
            }
            else //sinon m_additionalScenes sera la scene active
            {
                sceneToActivate = SceneManager.GetSceneByName(m_additionalScenes[0].SceneName);
            }

            OnLevelLoaded();
            while (!MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>().IsLoaded)
            {
                yield return null;
            }
            
            
            if (m_loadingScreenActive)
            {
                op = SceneManager.UnloadSceneAsync(m_loadingScreen.SceneName);
                while(!op.isDone)
                {
                    yield return null;
                }
                m_loadingScreenActive = false;
            }
            
        }

        private void OnLevelLoaded()
        {
            SceneManager.SetActiveScene(sceneToActivate);
            MOtterApplication.GetInstance().GAMEMANAGER.SaveCurrentData();
        }
        #endregion

    }

}