using ProjElf.SceneData;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Root : MonoBehaviour
{
    [SerializeField]
    private SceneData m_firstSceneData = null;

    private void Awake()
    {
        
    }

    private void Start()
    {
        StartCoroutine(StartGameApplicationAndCloseRoot());
    }

    IEnumerator StartGameApplicationAndCloseRoot()
    {
        m_firstSceneData.LoadLevel();
        yield return new WaitForSeconds(5f);
        SceneManager.UnloadSceneAsync(0);
    }
}
