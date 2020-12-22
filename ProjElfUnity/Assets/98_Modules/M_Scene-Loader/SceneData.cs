using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOtter;
using UnityEngine.SceneManagement;
using System;
using MOtter.StatesMachine;

namespace ProjElf.SceneData
{
    [CreateAssetMenu(fileName = "New SceneData", menuName = "SceneDatas/Data")]
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

       
        [SerializeField] private string m_levelName = null;

        //reference vers m_levelName
        public string LevelName=>m_levelName;

        [SerializeField] private LoadSceneMode m_defaultLoadMode;
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
            var currentGameMode = MOtterApplication.GetInstance().GAMEMANAGER.GetCurrentMainStateMachine<MainStatesMachine>();
            m_currentLoadSceneMode = loadMode;
            if (currentGameMode != null)
            {
                Coroutine routine = currentGameMode.StartCoroutine(currentGameMode.UnloadAsync(LoadScenes));
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
            op = SceneManager.LoadSceneAsync(m_mainScene.SceneName, LoadSceneMode.Additive);
            Debug.Log("LOADING " + m_mainScene.SceneName);
            op.completed += OnLevelLoaded;
            //charger additionalScenes 
            for (int i = 0; i < m_additionalScenes.Length; i++)
            {
                if (i == 0)
                {
                    op.completed -= OnLevelLoaded;
                }
                op = SceneManager.LoadSceneAsync(m_additionalScenes[i].SceneName, LoadSceneMode.Additive);//empeche la supperssion de la scene precedente
                if (i == 0)
                {
                    op.completed += OnLevelLoaded;
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
        }

        private void OnLevelLoaded(AsyncOperation obj)
        {
            SceneManager.SetActiveScene(sceneToActivate);
            obj.completed -= OnLevelLoaded;
            MOtterApplication.GetInstance().GAMEMANAGER.SaveCurrentData();
            if (m_currentLoadSceneMode == LoadSceneMode.Single)
            {
                MOtterApplication.GetInstance().GAMEMANAGER.UnloadScenesData();
            }
        }
        #endregion

        #region LevelUnloading
        public void UnloadLevel()
        {
            MOtterApplication.GetInstance().StartCoroutine(UnloadingRoutine());
        }

        IEnumerator UnloadingRoutine()
        {
            AsyncOperation op;
            op = SceneManager.UnloadSceneAsync(SceneManager.GetSceneByName(m_mainScene.SceneName).buildIndex);
            yield return op;
            Debug.Log("UNLOADING " + m_mainScene.SceneName);
            for (int i = 0; i < m_additionalScenes.Length; i++)
            {
                op = SceneManager.UnloadSceneAsync(m_additionalScenes[i].SceneName);
                yield return op;
            }
        }
        #endregion
    }

}