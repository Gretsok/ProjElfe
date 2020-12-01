using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MOtter;
using UnityEngine.SceneManagement;


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

        public void LoadLevel()
        {
            //passe le m_default
            LoadLevel(m_defaultLoadMode);
        }

        public void LoadLevel(LoadSceneMode loadMode)
        {
            //On load une scene(main + additionalScenes[])
            SceneManager.LoadSceneAsync(m_mainScene.SceneName,loadMode);
            //charger additionalScenes 
            for(int i =0; i<m_additionalScenes.Length; i++)
            { 
                SceneManager.LoadSceneAsync(m_additionalScenes[i].SceneName, LoadSceneMode.Additive);//empeche la supperssion de la scene precedente
            }
            if (m_additionalScenes.Length == 0)// Si il n'y a pas d'additional scene -> m_main sera la principale 
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(m_mainScene.SceneName));
            }
            else //sinon m_additionalScenes sera la scene active
            {
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(m_additionalScenes[0].SceneName));
            }
        }   
    }

}